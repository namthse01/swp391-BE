using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Command.Add;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entities.Category>(request);
        await _unitOfWork.Repository<Domain.Entities.Category>().AddAsync(category);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}