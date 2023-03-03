using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Command.Delete
{
    public partial class CategoryDeleteCommand
    {
        public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CategoryDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }          
            public async Task<Response<Guid>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
            {
                var category = await _unitOfWork.Repository<Domain.Entities.Category>().FindSingleAsync(x => x.Id == request.Id);
                if (category == null)
                {
                    throw new ApiException("ID not found");
                }
                await _unitOfWork.Repository<Domain.Entities.Category>().DeleteAsync(category);
                await _unitOfWork.CommitAsync();
                return new Response<Guid>();
            }
        }
    }
}
