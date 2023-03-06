using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Command.Delete
{
    public class TransactionServiceDeleteCommandHandler : IRequestHandler<TransactionServiceDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionServiceDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(TransactionServiceDeleteCommand request, CancellationToken cancellationToken)
        {
            var transactionService = await _unitOfWork.Repository<Domain.Entities.TransactionService>().FindSingleAsync(x => x.Id == request.Id);
            if (transactionService == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.TransactionService>().DeleteAsync(transactionService);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}

