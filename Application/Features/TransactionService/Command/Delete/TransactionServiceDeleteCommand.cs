using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Command.Delete
{
    public class TransactionServiceDeleteCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
