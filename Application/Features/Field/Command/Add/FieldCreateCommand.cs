using Application.Wrappers;
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