using Application.Wrappers;
using MediatR;

namespace Application.Features.Order.Command.Add;

public class OrderCreateCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid? TransactionId { get; set; }
}