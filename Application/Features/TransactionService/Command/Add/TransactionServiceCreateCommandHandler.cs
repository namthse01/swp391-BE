using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Command.Add
{
    public class TransactionServiceCreateCommandHandler : IRequestHandler<TransactionServiceCreateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionServiceCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(TransactionServiceCreateCommand request, CancellationToken cancellationToken)
        {
            var transactionService = _mapper.Map<Domain.Entities.TransactionService>(request);
            await _unitOfWork.Repository<Domain.Entities.TransactionService>().AddAsync(transactionService);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
