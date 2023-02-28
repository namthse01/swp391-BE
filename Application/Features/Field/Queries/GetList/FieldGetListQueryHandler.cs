using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Field.Queries.GetList;

public class FieldGetListQueryHandler : IRequestHandler<FieldGetListQuery, PagedResponse<List<FieldListViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FieldGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<List<FieldListViewModel>>> Handle(FieldGetListQuery request,
        CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Repository<Domain.Entities.Field>()
            .GetAll(x => string.IsNullOrEmpty(request.Name) || x.Name.ToLower().Contains(request.Name));
        int total = await query.CountAsync();
        if (total == 0)
        {
            new PagedResponse<List<FieldListViewModel>>(0);
        }

        var fields = await query.ToListAsync();
        var viewFields = _mapper.Map<List<FieldListViewModel>>(fields);

        return new PagedResponse<List<FieldListViewModel>>(total, viewFields);
    }
}