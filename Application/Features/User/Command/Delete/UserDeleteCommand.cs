using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Command.Delete
{
    public class UserDeleteCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
