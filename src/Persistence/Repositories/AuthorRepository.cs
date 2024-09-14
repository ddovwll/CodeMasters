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

    public async Task<AuthorModel> AddAuthorAsync(AuthorModel author)
    {
        await database.Authors.AddAsync(author);
        await database.SaveChangesAsync();
        
        return author;
    }

    public async Task<AuthorModel> GetByIdAsync(Guid authorId)
    {
        var author = await database.Authors.FindAsync(authorId) ?? new AuthorModel();
        return author;
    }

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

    public async Task<AuthorModel> UpdateAuthorAsync(AuthorModel author)
    {
        database.Authors.Update(author);
        await database.SaveChangesAsync();

        return author;
    }

    public async Task<List<AuthorModel>> GetFamousAuthor()
    {
        var authors = await database.Authors.Where(a=>a.IsFamous == true).ToListAsync();
        return authors;
    }
}