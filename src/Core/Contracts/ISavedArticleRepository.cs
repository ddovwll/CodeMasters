using Core.Models;

namespace Core.Contracts;

public interface ISavedArticleRepository
{
    Task SaveAsync(SavedArticleModel article);
    Task<List<SavedArticleModel>> GetAllAsync();
}