using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Queries.Detail
{
    public class ServiceDetailQuery : IRequest<Response<ServiceDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
