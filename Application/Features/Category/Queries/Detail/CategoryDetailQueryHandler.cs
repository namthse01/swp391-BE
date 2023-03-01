using Application.Features.Category.Queries.Detail;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.Detail
{
    public class CategoryDetailQueryHandler : IRequestHandler<CategoryDetailQuery, Response<CategoryDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<CategoryDetailResponse>> Handle(CategoryDetailQuery request,
            CancellationToken cancellationToken)
        {
            var categoryDetail = await _unitOfWork.Repository<Domain.Entities.Category>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new CategoryDetailResponse
                {
                    Name = x.Name,
                }
                )
                .FirstOrDefaultAsync();

            return new Response<CategoryDetailResponse>(categoryDetail);
        }
    }
}