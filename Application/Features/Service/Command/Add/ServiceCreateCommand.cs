using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Command.Add
{
    public class ServiceCreateCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid ManagerId { get; set; }
    }
}
