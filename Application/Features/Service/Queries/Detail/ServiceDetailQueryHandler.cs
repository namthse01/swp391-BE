using Application.Features.Field.Queries.Detail;
using Application.Features.Manager.Queries.Detail;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Queries.Detail
{
    public class ServiceDetailQueryHandler : IRequestHandler<ServiceDetailQuery, Response<ServiceDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<ServiceDetailResponse>> Handle(ServiceDetailQuery request, CancellationToken cancellationToken)
        {
            var serviceDetail = await _unitOfWork.Repository<Domain.Entities.Service>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new ServiceDetailResponse
                {
                    Name = x.Name,
                    Price = x.Price,
                    Manager = x.ManagerId != null
                        ? new ServiceManagerResponse()
                        {
                            Username = x.Manager.User.Username,
                            Phone = x.Manager.User.Phone
                        }
                        : null
                })
                .FirstOrDefaultAsync();

            return new Response<ServiceDetailResponse>(serviceDetail);
        }
    }
}
