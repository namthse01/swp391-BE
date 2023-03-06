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

namespace Application.Features.Transaction.Command.Delete
{
    internal class TransactionDeleteCommandHandler : IRequestHandler<TransactionDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(TransactionDeleteCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.Repository<Domain.Entities.Transaction>().FindSingleAsync(x => x.Id == request.Id);
            if (transaction == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.Transaction>().DeleteAsync(transaction);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
