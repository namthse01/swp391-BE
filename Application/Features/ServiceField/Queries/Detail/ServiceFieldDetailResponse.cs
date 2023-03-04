using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceField.Queries.Detail
{
    public class ServiceFieldDetailResponse
    {
        public ServiceFieldServiceResponse Service { get; set; }
        public ServiceFieldFieldResponse Field { get; set; } 
    }

    public class ServiceFieldServiceResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ServiceFieldFieldResponse
    {
        public string Name { get; set; }
    }
}
