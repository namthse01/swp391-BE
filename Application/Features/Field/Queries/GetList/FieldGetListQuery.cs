using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Field.Queries.GetList
{
    public class FieldGetListQuery : FilterRequestModel, IRequest<PagedResponse<List<FieldListViewModel>>>
    {
        public string Name { get; set; }
    }
}