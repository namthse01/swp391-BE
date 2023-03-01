using Application.Features.Field.Queries.GetList;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Category.Queries.Detail;

public class CategoryDetailQuery : IRequest<Response<CategoryDetailResponse>>
{
    public Guid Id { get; set; }
}