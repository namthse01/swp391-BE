using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceField.Queries.Detail
{
    public class ServiceFieldDetailQuery : IRequest<Response<ServiceFieldDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
