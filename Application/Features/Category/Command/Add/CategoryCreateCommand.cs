using Application.Wrappers;
using MediatR;

namespace Application.Features.Category.Command.Add;

public class CategoryCreateCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; }
}