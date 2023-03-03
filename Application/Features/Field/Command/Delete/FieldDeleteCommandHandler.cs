﻿using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Field.Command.Delete
{
    public partial class CategoryDeleteCommand
    {
        public class ManagerDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public ManagerDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }          
            public async Task<Response<Guid>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
            {
                var field = await _unitOfWork.Repository<Domain.Entities.Field>().FindSingleAsync(x => x.Id == request.Id);
                if (field == null)
                {
                    throw new ApiException("ID not found");
                }
                await _unitOfWork.Repository<Domain.Entities.Field>().DeleteAsync(field);
                await _unitOfWork.CommitAsync();
                return new Response<Guid>();
            }
        }
    }
}
