using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Player.Command.Delete
{
    public class PlayerDeleteCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
