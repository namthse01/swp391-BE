using Application.Features.Field.Queries.GetList;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Field.Queries.Detail;

public class FieldDetailQuery : IRequest<Response<FieldDetailResponse>>
{
    public Guid Id { get; set; }
}