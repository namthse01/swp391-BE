using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Manager.Command.Update;

public class OrderUpdateCommandHandler : IRequestHandler<ManagerUpdateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(ManagerUpdateCommand request, CancellationToken cancellationToken)
    {
        var manager = await _unitOfWork.Repository<Domain.Entities.Manager>().FindSingleAsync(x => x.Id == request.Id);
        if (manager == null)
        {
            throw new ApiException("ID not found");
        }
        manager.UserId = request.Id;
        manager.RoleId = request.Id;
        await _unitOfWork.Repository<Domain.Entities.Manager>().UpdateAsync(manager);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}