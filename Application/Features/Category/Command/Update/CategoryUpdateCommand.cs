using Application.Wrappers;
using MediatR;

namespace Application.Features.Category.Command.Update;

public class CategoryUpdateCommand : IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}