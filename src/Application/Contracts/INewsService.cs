using Core.Models;

namespace Application.Contracts;

public interface INewsService
{
    Task<List<ArticleModel>> GetArticlesAsync(string q = "новости");
}