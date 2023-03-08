using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Category.Queries.GetList
{
    public class CategoryGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<CategoryListViewModel>>>
    {
        public string Name { get; set; }
    }
}