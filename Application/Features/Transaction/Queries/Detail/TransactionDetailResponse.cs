using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.Detail
{
    public class TransactionDetailResponse
    {
        public string Name { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
        public TransactionPlayerResponse Player { get; set; }
        public TransactionFieldResponse Field { get; set; }
        
    }

    public class TransactionFieldResponse
    {
        public string Name { get; set; }
    }

    public class TransactionPlayerResponse
    {
        
    }
}
