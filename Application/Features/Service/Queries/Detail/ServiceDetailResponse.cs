using Application.Features.Manager.Queries.Detail;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Queries.Detail
{
    public class ServiceDetailResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ServiceManagerResponse Manager { get; set; }
    }
    public class ServiceManagerResponse
    {
        public string Username { get; set; }
        public string Phone { get; set; }
    }
}
