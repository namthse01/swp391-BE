using Application.Wrappers;
using MediatR;

namespace Application.Features.Manager.Command.Update;

public class ManagerUpdateCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }

}