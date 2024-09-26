using Application.Contracts;
using Core.Models;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace Infrastructure.Services;

public class NewsService : INewsService
{
    private readonly NewsApiClient newsApiClient;

    public NewsService(NewsApiClient newsApiClient)
    {
        this.newsApiClient = newsApiClient;
    }

    /// <summary>
    /// Получение новостей
    /// </summary>
    /// <param name="q">тема новостей; default = "новости"</param>
    /// <returns>List of ArticleModel</returns>
    public async Task<List<ArticleModel>> GetArticlesAsync(string q = "новости")
    {
        var request = new EverythingRequest()
        {
            Q = q,
            Language = Languages.RU,
            SortBy = SortBys.Popularity,
        };
        
        var articles = new List<ArticleModel>();
        
        var response = await newsApiClient.GetEverythingAsync(request);

        if (response.Status == Statuses.Ok)
        {
            foreach (var article in response.Articles)
            {
                articles.Add(new()
                {
                    Author = article.Author,
                    Description = article.Description,
                    PublishedAt = article.PublishedAt,
                    Title = article.Title,
                    Url = article.Url
                });
            }
        }
        
        return articles;
    }
}