using Core.Models;

namespace Core.Contracts;

public interface INewsService
{
    /// <summary>
    /// Получение новостей
    /// </summary>
    /// <param name="keyword">тема</param>
    /// <returns>List of ArticleModel</returns>
    Task<List<ArticleModel>> GetNewsAsync(string keyword);
}