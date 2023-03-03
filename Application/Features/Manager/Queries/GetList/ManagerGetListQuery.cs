using System;
using System.Collections.Generic;
using System.Linq;
using Application.Filters;
using Application.Wrappers;
using MediatR;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Manager.Queries.GetList
{
    public class ManagerGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<ManagerListViewModel>>>
    {
    }
}
