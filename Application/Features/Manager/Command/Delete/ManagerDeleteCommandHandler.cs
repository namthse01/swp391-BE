using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Manager.Command.Delete
{
    public partial class ManagerDeleteCommand
    {
        public class ManagerDeleteCommandHandler : IRequestHandler<ManagerDeleteCommand, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public ManagerDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }          
            public async Task<Response<Guid>> Handle(ManagerDeleteCommand request, CancellationToken cancellationToken)
            {
                var manager = await _unitOfWork.Repository<Domain.Entities.Manager>().FindSingleAsync(x => x.Id == request.Id);
                if (manager == null)
                {
                    throw new ApiException("ID not found");
                }
                await _unitOfWork.Repository<Domain.Entities.Manager>().DeleteAsync(manager);
                await _unitOfWork.CommitAsync();
                return new Response<Guid>();
            }
        }
    }
}
