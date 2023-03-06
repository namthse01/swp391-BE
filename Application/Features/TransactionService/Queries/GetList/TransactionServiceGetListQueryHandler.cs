using Application.Features.Field.Queries.GetList;
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

namespace Application.Features.TransactionService.Queries.GetList
{
    internal class TransactionServiceGetListQueryHandler : IRequestHandler<TransactionServiceGetListQuery, PagedResponse<List<TransactionServiceListViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionServiceGetListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<TransactionServiceListViewModel>>> Handle(TransactionServiceGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.TransactionService>()
            .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<TransactionServiceListViewModel>>(0);
            }

            var transactionServices = await query.ToListAsync();
            var viewTransactionServices = _mapper.Map<List<TransactionServiceListViewModel>>(transactionServices);

            return new PagedResponse<List<TransactionServiceListViewModel>>(total, viewTransactionServices);
        }
    }
}
