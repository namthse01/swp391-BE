using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceField.Queries.GetList
{
    public class ServiceFieldGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<ServiceFieldListViewModel>>>
    {
        public Guid Id { get; set; }
    }
}
