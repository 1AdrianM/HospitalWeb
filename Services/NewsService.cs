using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Scripting;

namespace Proyecto_Hospital.Services
{
    public class NewsService
    {
        private readonly NewsApiClient newsApiClient;

        public NewsService(string apiKey)
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
    }
}
/*< script src = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" ></ script >*/