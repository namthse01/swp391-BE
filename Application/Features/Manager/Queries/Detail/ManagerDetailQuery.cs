using Application.Features.Field.Queries.GetList;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Manager.Queries.Detail;

public class ManagerDetailQuery : IRequest<Response<ManagerDetailResponse>>
{
    public Guid Id { get; set; }
}