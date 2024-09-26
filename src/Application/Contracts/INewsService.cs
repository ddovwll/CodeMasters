using Core.Models;

namespace Application.Contracts;

public interface INewsService
{
    /// <summary>
    /// Получение новостей
    /// </summary>
    /// <param name="q">тема новостей; default = "новости"</param>
    /// <returns>List of ArticleModel</returns>
    Task<List<ArticleModel>> GetArticlesAsync(string q = "новости");
}