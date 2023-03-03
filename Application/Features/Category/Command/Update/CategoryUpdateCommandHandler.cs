using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Command.Update;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Response<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Guid>> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Repository<Domain.Entities.Category>().FindSingleAsync(x => x.Id == request.Id);
        if (category == null)
        {
            throw new ApiException("ID not found");
        }
        category.Name = request.Name;
        await _unitOfWork.Repository<Domain.Entities.Category>().UpdateAsync(category);
        await _unitOfWork.CommitAsync();
        return new Response<Guid>();
    }
}