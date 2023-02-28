using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Field.Queries.Detail
{
    public class FieldDetailQueryHandler : IRequestHandler<FieldDetailQuery, Response<FieldDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FieldDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<FieldDetailResponse>> Handle(FieldDetailQuery request,
            CancellationToken cancellationToken)
        {
            var fieldDetail = await _unitOfWork.Repository<Domain.Entities.Field>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new FieldDetailResponse
                {
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description,
                    Owner = x.ManagerId != null
                        ? new FieldOwnerResponse()
                        {
                            Name = x.Manager.User.Username,
                            Phone = x.Manager.User.Phone
                        }
                        : null,
                    CategoryName = x.Category.Name,
                    Services = x.ServiceFields.Select(y => new FieldServiceResponse()
                    {
                        Name = y.Service.Name,
                        Price = y.Service.Price,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return new Response<FieldDetailResponse>(fieldDetail);
        }
    }
}