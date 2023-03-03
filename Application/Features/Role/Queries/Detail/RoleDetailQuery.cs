using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Role.Queries.Detail
{
    public class RoleDetailQuery : IRequest<Response<RoleDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
