using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Field.Command.Add;

public class FieldCreateCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public Guid? ManagerId { get; set; }
    public Guid CategoryId { get; set; }
}

public class FieldCreateCommandHandler : IRequestHandler<FieldCreateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FieldCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(FieldCreateCommand request, CancellationToken cancellationToken)
    {
        var field = _mapper.Map<Domain.Entities.Field>(request);
        await _unitOfWork.Repository<Domain.Entities.Field>().AddAsync(field);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}