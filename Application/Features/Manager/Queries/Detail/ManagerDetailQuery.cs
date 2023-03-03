﻿using Application.Features.Field.Queries.GetList;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Manager.Queries.Detail;

public class OrderDetailQuery : IRequest<Response<OrderDetailResponse>>
{
    public Guid Id { get; set; }
}