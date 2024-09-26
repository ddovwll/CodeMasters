using Core.Models;

namespace Core.Contracts;

public interface ISavedArticleRepository
{
    /// <summary>
    /// Запись статьи в БД
    /// </summary>
    /// <param name="article">статья</param>
    /// <returns></returns>
    Task SaveAsync(SavedArticleModel article);
    /// <summary>
    /// Получение всех записей из БД
    /// </summary>
    /// <returns>List of SavedArticleModel</returns>
    Task<List<SavedArticleModel>> GetAllAsync();
}