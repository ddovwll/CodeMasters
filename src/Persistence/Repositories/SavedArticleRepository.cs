using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class SavedArticleRepository : ISavedArticleRepository
{
    private readonly DbHelper database;

    public SavedArticleRepository(DbHelper database)
    {
        this.database = database;
    }

    /// <summary>
    /// Запись статьи в БД
    /// </summary>
    /// <param name="article">статья</param>
    /// <returns></returns>
    public async Task SaveAsync(SavedArticleModel article)
    {
        await database.SavedArticles.AddAsync(article);
        await database.SaveChangesAsync();
    }
    /// <summary>
    /// Получение всех записей из БД
    /// </summary>
    /// <returns>List of SavedArticleModel</returns>
    public async Task<List<SavedArticleModel>> GetAllAsync()
    {
        var articles = await database.SavedArticles.ToListAsync();
        return articles;
    }
}