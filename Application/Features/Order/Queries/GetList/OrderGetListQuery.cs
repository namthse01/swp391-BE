using System;
using System.Collections.Generic;
using System.Linq;
using Application.Filters;
using Application.Wrappers;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries.GetList
{
    public class OrderGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<OrderListViewModel>>>
    {
        public string Name { get; set; }
    }
}
