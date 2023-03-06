using Application.Filters;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Queries.GetList
{
    public class TransactionServiceGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<TransactionServiceListViewModel>>>
    {
    }
}
