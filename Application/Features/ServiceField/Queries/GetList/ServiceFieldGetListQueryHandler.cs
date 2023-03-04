using Application.Features.Service.Queries.GetList;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceField.Queries.GetList
{
    public class ServiceFieldGetListQueryHandler : IRequestHandler<ServiceFieldGetListQuery, PagedResponse<List<ServiceFieldListViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceFieldGetListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ServiceFieldListViewModel>>> Handle(ServiceFieldGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.ServiceField>()
            .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<ServiceFieldListViewModel>>(0);
            }

            var serviceFields = await query.ToListAsync();
            var viewServiceFields = _mapper.Map<List<ServiceFieldListViewModel>>(serviceFields);

            return new PagedResponse<List<ServiceFieldListViewModel>>(total, viewServiceFields);
        }
    }
}
