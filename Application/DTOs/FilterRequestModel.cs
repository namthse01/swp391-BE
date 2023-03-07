namespace Application.DTOs;

public class FilterRequestModel
{
    public FilterRequestModel()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}