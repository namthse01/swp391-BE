using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.GetList
{
    public class TransactionListViewModel 
    {
        public string Name { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }
    }
}
