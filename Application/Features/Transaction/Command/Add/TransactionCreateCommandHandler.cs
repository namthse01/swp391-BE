using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Command.Add
{
    public class TransactionCreateCommandHandler : IRequestHandler<TransactionCreateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Domain.Entities.Transaction>(request);
            await _unitOfWork.Repository<Domain.Entities.Transaction>().AddAsync(transaction);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
