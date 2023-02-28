using Application.Wrappers;
using MediatR;

namespace Application.Features.Field.Command.Add;

public class FieldUpdateCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}