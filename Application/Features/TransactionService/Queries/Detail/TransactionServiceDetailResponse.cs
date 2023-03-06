using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Queries.Detail
{
    public class TransactionServiceDetailResponse
    {
        public TransactionServiceAndServiceResponse Service { get; set; }
        public TransactionServiceAndTransactionResponse Transaction { get; set; }
    }

    public class TransactionServiceAndTransactionResponse
    {
        public string Name { get; set; }
        public int Slot { get; set; }
    }

    public class TransactionServiceAndServiceResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
