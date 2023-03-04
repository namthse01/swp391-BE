using Application.Features.Field.Queries.GetList;
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

namespace Application.Features.Service.Queries.GetList
{
    public class ServiceGetListQueryHandler : IRequestHandler<ServiceGetListQuery, PagedResponse<List<ServiceListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<ServiceListViewModel>>> Handle(ServiceGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Service>()
            .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<ServiceListViewModel>>(0);
            }

            var services = await query.ToListAsync();
            var viewServices = _mapper.Map<List<ServiceListViewModel>>(services);

            return new PagedResponse<List<ServiceListViewModel>>(total, viewServices);
        }
    }
}
