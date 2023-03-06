using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Command.Add
{
    public class TransactionServiceCreateCommand : IRequest<Response<Guid>>
    {
        public Guid ServiceId { get; set; }
        public Guid TransactionId { get; set; }
    }
}
