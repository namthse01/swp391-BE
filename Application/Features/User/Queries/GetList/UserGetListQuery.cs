using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetList
{
    public class UserGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<UserListViewModel>>>
    {
        public string Username { get; set; }
    }
}
