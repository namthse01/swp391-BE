﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Role.Command.Add
{
    public class RoleCreateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
