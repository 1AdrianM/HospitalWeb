// Interfaz
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

public interface INewsServiceApiClient
{
    List<Article> GetTopNews(TopHeadlinesRequest request);
}

// Clase de implementación
public class NewsApiClientWrapper : INewsServiceApiClient
{
    private readonly NewsApiClient _newsApiClient;

    public NewsApiClientWrapper(string apiKey)
    {
        _newsApiClient = new NewsApiClient(apiKey);
    }

    public List<Article> GetTopNews(TopHeadlinesRequest request)
    {
        var articlesResponse = _newsApiClient.GetTopHeadlines(request);
        return articlesResponse.Status == Statuses.Ok ? articlesResponse.Articles : new List<Article>();
    }
}
