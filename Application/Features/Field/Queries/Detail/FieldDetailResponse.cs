using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Features.Field.Queries.Detail
{
    public class FieldDetailResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public FieldOwnerResponse Owner { get; set; }
        public FieldCategoryResponse Category { get; set; }
        public List<FieldServiceResponse> Services { get; set; }
    }

    public class FieldServiceResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class FieldCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class FieldOwnerResponse
    {
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}