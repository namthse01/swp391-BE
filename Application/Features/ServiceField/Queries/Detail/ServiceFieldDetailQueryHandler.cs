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

namespace Application.Features.ServiceField.Queries.Detail
{
    public class ServiceFieldDetailQueryHandler : IRequestHandler<ServiceFieldDetailQuery, Response<ServiceFieldDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceFieldDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ServiceFieldDetailResponse>> Handle(ServiceFieldDetailQuery request, CancellationToken cancellationToken)
        {
            var serviceFieldDetail = await _unitOfWork.Repository<Domain.Entities.ServiceField>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new ServiceFieldDetailResponse
                {                   
                    Service = new ServiceFieldServiceResponse()
                    {
                        Name = x.Service.Name,
                        Price = x.Service.Price,
                    },
                    Field = new ServiceFieldFieldResponse()
                    {
                        Name = x.Field.Name
                    }
                })
                .FirstOrDefaultAsync();
            return new Response<ServiceFieldDetailResponse>(serviceFieldDetail);
        }
    }
}
