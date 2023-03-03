using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Field.Command.Delete
{
    public partial class FieldDeleteCommand
    {
        public class FieldDeleteCommandHandler : IRequestHandler<FieldDeleteCommand, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public FieldDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }          
            public async Task<Response<Guid>> Handle(FieldDeleteCommand request, CancellationToken cancellationToken)
            {
                var field = await _unitOfWork.Repository<Domain.Entities.Field>().FindSingleAsync(x => x.Id == request.Id);
                if (field == null)
                {
                    throw new ApiException("ID not found");
                }
                await _unitOfWork.Repository<Domain.Entities.Field>().DeleteAsync(field);
                await _unitOfWork.CommitAsync();
                return new Response<Guid>();
            }
        }
    }
}
