using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Command.Update;

public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Repository<Domain.Entities.Order>().FindSingleAsync(x => x.Id == request.Id);
        if (order == null)
        {
            throw new ApiException("ID not found");
        }
        order.Name= request.Name;
        order.TotalPrice = request.TotalPrice;
        order.TransactionId = request.Id;
        await _unitOfWork.Repository<Domain.Entities.Order>().UpdateAsync(order);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}