using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.Detail
{
    public class UserDetailQuery : IRequest<Response<UserDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
