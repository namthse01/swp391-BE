using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.GetList
{
    public class TransactionGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<TransactionListViewModel>>>
    {
        public string Name { get; set; }
    }
}
