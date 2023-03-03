using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Player.Queries.Detail
{
    public class PlayerDetailQuery : IRequest<Response<PlayerDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
