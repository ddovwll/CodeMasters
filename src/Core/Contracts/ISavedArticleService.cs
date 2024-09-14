using Core.Models;

namespace Core.Contracts;

public interface ISavedArticleService
{
    Task SaveAsync(SavedArticleModel article);
    Task<List<SavedArticleModel>> GetAllAsync();
}