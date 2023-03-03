using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Command.Delete
{
    public partial class OrderDeleteCommand
    {
        public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public OrderDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }          
            public async Task<Response<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
            {
                var order = await _unitOfWork.Repository<Domain.Entities.Order>().FindSingleAsync(x => x.Id == request.Id);
                if (order == null)
                {
                    throw new ApiException("ID not found");
                }
                await _unitOfWork.Repository<Domain.Entities.Order>().DeleteAsync(order);
                await _unitOfWork.CommitAsync();
                return new Response<Guid>();
            }
        }
    }
}
