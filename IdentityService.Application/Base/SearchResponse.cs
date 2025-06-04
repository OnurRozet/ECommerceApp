namespace IdentityService.Application.Base;

public class SearchResponse<T>
{
    public SearchResponse()
    {
        SearchResult = new List<T>();
    }
    public List<T> SearchResult { get; set; }
    public int TotalItemCount { get; set; }
}