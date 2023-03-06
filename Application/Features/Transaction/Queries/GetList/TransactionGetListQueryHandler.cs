using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.GetList
{
    public class TransactionGetListQueryHandler : IRequestHandler<TransactionGetListQuery, PagedResponse<List<TransactionListViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionGetListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<TransactionListViewModel>>> Handle(TransactionGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Transaction>()
                .GetAll(x => string.IsNullOrEmpty(request.Name) || x.Name.ToLower().Contains(request.Name));
            int total = await query.CountAsync();
            if (total == 0) 
            {
                new PagedResponse<List<TransactionListViewModel>>(0);
            }
            var transactions = await query.ToListAsync();
            var viewTransactions = _mapper.Map<List<TransactionListViewModel>>(transactions);
            return new PagedResponse<List<TransactionListViewModel>>(total, viewTransactions);
        }
    }
}
