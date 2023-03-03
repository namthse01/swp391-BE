using Application.Wrappers;
using MediatR;

namespace Application.Features.Order.Command.Update;

public class OrderUpdateCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal TotalPrice { get; set; }
}