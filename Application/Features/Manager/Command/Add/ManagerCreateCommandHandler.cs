using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Manager.Command.Add;

public class OrderCreateCommandHandler : IRequestHandler<ManagerCreateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(ManagerCreateCommand request, CancellationToken cancellationToken)
    {
        var manager = _mapper.Map<Domain.Entities.Manager>(request);
        await _unitOfWork.Repository<Domain.Entities.Manager>().AddAsync(manager);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}