using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Category.Queries.GetList;

    public class CategoryGetListQueryHandler : IRequestHandler<CategoryGetListQuery, PagedResponse<List<CategoryListViewModel>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<List<CategoryListViewModel>>> Handle(CategoryGetListQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Repository<Domain.Entities.Category>()
            .GetAll(x => string.IsNullOrEmpty(request.Name) || x.Name.ToLower().Contains(request.Name));
        int total = await query.CountAsync();
        if (total == 0)
        {
            new PagedResponse<List<CategoryListViewModel>>(0);
        }

        var categories = await query.ToListAsync();

        var viewCategories = _mapper.Map<List<CategoryListViewModel>>(categories);

        return new PagedResponse<List<CategoryListViewModel>>(total, viewCategories);
    }
}

