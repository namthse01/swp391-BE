using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Command.Update
{
    public class TransactionServiceUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
