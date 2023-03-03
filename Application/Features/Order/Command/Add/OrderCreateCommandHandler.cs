using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Command.Add;

public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Domain.Entities.Order>(request);
        await _unitOfWork.Repository<Domain.Entities.Order>().AddAsync(order);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}