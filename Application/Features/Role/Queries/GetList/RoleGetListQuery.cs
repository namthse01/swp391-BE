using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Role.Queries.GetList
{
    public class RoleGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<RoleListViewModel>>>
    {
        public string Name { get; set; }
    }
}
