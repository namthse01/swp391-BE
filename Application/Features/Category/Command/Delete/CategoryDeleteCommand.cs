using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Category.Command.Delete
{
    public partial class CategoryDeleteCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
