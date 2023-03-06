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

namespace Application.Features.TransactionService.Command.Update
{
    public class TransactionServiceUpdateCommandHandler : IRequestHandler<TransactionServiceUpdateCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionServiceUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(TransactionServiceUpdateCommand request, CancellationToken cancellationToken)
        {
            var transactionService = await _unitOfWork.Repository<Domain.Entities.TransactionService>().FindSingleAsync(x => x.Id == request.Id);
            if (transactionService == null)
            {
                throw new ApiException("ID not found");
            }

            await _unitOfWork.Repository<Domain.Entities.TransactionService>().UpdateAsync(transactionService);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
