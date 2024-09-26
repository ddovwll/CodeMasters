using Application.Contracts;
using Core.Models;

namespace Application.Services;

public class NewsService : Core.Contracts.INewsService
{
    private readonly INewsService newsService;

    public NewsService(INewsService newsService)
    {
        this.newsService = newsService;
    }
    /// <summary>
    /// Получение новостей
    /// </summary>
    /// <param name="keyword">тема</param>
    /// <returns>List of ArticleModel</returns>
    public async Task<List<ArticleModel>> GetNewsAsync(string keyword)
    {
        List<ArticleModel> articles;
        
        if(string.IsNullOrEmpty(keyword))
            articles = await newsService.GetArticlesAsync();
        else articles = await newsService.GetArticlesAsync(keyword);

        return articles;
    }
}