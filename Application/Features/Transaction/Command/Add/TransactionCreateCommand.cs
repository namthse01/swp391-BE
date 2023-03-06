using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Command.Add
{
    public class TransactionCreateCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
    }
}
