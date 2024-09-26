using Core.Contracts;
using Core.Models;

namespace Application.Services;

public class SavedArticleService : ISavedArticleService
{
    private readonly ISavedArticleRepository savedArticleRepository;

    public SavedArticleService(ISavedArticleRepository savedArticleRepository)
    {
        this.savedArticleRepository = savedArticleRepository;
    }
    /// <summary>
    /// Запись статьи в БД
    /// </summary>
    /// <param name="article">статья</param>
    /// <returns></returns>
    public async Task SaveAsync(SavedArticleModel article)
    {
        await savedArticleRepository.SaveAsync(article);
    }
    /// <summary>
    /// Получение всех записей из БД
    /// </summary>
    /// <returns>List of SavedArticleModel</returns>
    public async Task<List<SavedArticleModel>> GetAllAsync()
    {
        return await savedArticleRepository.GetAllAsync();
    }
}