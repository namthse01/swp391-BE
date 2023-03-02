using Application.Features.Field.Queries.GetList;
using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetList
{
    public class CategoryGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<CategoryListViewModel>>>
    {
        public string Name { get; set; }
    }

}
