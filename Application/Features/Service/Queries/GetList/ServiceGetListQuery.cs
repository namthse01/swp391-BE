using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Queries.GetList
{
    public class ServiceGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<ServiceListViewModel>>>
    {
        public string Name { get; set; }
    }
}
