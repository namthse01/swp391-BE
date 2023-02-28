using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Field.Command.Add;

public class FieldUpdateCommandHandler : IRequestHandler<FieldUpdateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FieldUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(FieldUpdateCommand request, CancellationToken cancellationToken)
    {
        var field = await _unitOfWork.Repository<Domain.Entities.Field>().FindSingleAsync(x => x.Id == request.Id);
        if (field == null)
        {
            throw new ApiException("ID not found");
        }

        field.Name = request.Name;
        field.Address = request.Address;
        field.Description = request.Description;
        await _unitOfWork.Repository<Domain.Entities.Field>().UpdateAsync(field);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}