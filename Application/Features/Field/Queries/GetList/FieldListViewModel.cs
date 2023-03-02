using Application.Features.Category.Queries.GetList;
using Domain.Entities;

namespace Application.Features.Field.Queries.GetList;

public class FieldListViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public CategoryListViewModel Category { get; set; }
}