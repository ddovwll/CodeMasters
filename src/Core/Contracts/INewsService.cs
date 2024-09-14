using Core.Models;

namespace Core.Contracts;

public interface INewsService
{
    Task<List<ArticleModel>> GetNewsAsync(string keyword);
}