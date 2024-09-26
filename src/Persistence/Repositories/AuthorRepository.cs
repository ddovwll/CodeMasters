using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly DbHelper database;

    public AuthorRepository(DbHelper database)
    {
        this.database = database;
    }

    /// <summary>
    /// Добавление автора в БД
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> AddAuthorAsync(AuthorModel author)
    {
        await database.Authors.AddAsync(author);
        await database.SaveChangesAsync();
        
        return author;
    }

    /// <summary>
    /// Поиск автора по ID
    /// </summary>
    /// <param name="authorId">Id</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> GetByIdAsync(Guid authorId)
    {
        var author = await database.Authors.FindAsync(authorId) ?? new AuthorModel();
        return author;
    }

    /// <summary>
    /// Получение списка авторов
    /// </summary>
    /// <param name="skip">сколько пропустить эл-ов</param>
    /// <param name="take">сколько взять эл-ов</param>
    /// <returns>List of AuthorModel</returns>
    public async Task<List<AuthorModel>> GetAuthorsAsync(int skip, int take)
    {
        var authors = await database.Authors
            .Where(a=>a.IsFamous == false)
            .Skip(skip)
            .Take(take)
            .OrderByDescending(a => a.Name)
            .ToListAsync();
        
        return authors;
    }

    /// <summary>
    /// Обновление данных обавторе
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> UpdateAuthorAsync(AuthorModel author)
    {
        database.Authors.Update(author);
        await database.SaveChangesAsync();

        return author;
    }

    /// <summary>
    /// Получение списка всех известных людей
    /// </summary>
    /// <returns>List of AuthorModel</returns>
    public async Task<List<AuthorModel>> GetFamousAuthor()
    {
        var authors = await database.Authors.Where(a=>a.IsFamous == true).ToListAsync();
        return authors;
    }
}