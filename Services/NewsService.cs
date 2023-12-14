using NewsAPI.Constants;
using NewsAPI.Models;
using Proyecto_Hospital.Services;

public class NewsService
{
    private readonly INewsServiceApiClient _newsApiClient;

    public NewsService(INewsServiceApiClient newsApiClient)
    {
        _newsApiClient = newsApiClient;
    }

    public List<Article> GetTopNews(string query, int count = 10)
    {
        var request = new TopHeadlinesRequest { Q = query, Language = Languages.EN, PageSize = count };

        return _newsApiClient.GetTopNews(request);
    }
}
