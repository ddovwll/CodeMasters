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

    public async Task SaveAsync(SavedArticleModel article)
    {
        await savedArticleRepository.SaveAsync(article);
    }

    public async Task<List<SavedArticleModel>> GetAllAsync()
    {
        return await savedArticleRepository.GetAllAsync();
    }
}