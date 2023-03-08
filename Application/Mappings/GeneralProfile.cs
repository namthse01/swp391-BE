using Application.Features.Category.Queries.GetList;
using Application.Features.Field.Command.Add;
using Application.Features.Field.Command.Update;
using Application.Features.Field.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<Field, FieldListViewModel>().ReverseMap();
        CreateMap<FieldCreateCommand, Field>();
        CreateMap<FieldUpdateCommand, Field>().ReverseMap();
        CreateMap<Category, CategoryListViewModel>().ReverseMap();
    }
}