using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

namespace Proyecto_Hospital.Services
{
    public class NewsApiClientWrapper : INewsServiceApiClient
    {
        private readonly NewsApiClient newsApiClient;

        public NewsApiClientWrapper(string apiKey)
        {
            newsApiClient = new NewsApiClient(apiKey);
        }

        public List<Article> GetTopNews(string query, int count = 10)
        {
            var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
            {
                Q = query,
                Language = Languages.EN,
                PageSize = count
            });

            return articlesResponse.Status == Statuses.Ok ? articlesResponse.Articles : new List<Article>();
        }

        public List<Article> GetTopNews(TopHeadlinesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}