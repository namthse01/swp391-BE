namespace Application.Wrappers;

public class PagedResponse<T> : Response<T>
{
    public PagedResponse(int total, T data = default)
    {
        Total = total;
        Data = data;
        Message = null;
        Succeeded = true;
    }

    public int Total { get; set; }
}