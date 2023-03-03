using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries.Detail
{
    public class OrderDetailResponse
    {
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderTransactionResponse Transaction { get; set; }
    }
        public class OrderTransactionResponse
    {
        public string Name { get; set; }
    }
}