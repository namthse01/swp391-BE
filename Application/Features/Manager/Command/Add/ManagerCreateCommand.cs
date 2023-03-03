using Application.Wrappers;
using MediatR;

namespace Application.Features.Manager.Command.Add;

public class ManagerCreateCommand : IRequest<Response<Guid>>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}