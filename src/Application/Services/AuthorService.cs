using System.ComponentModel.DataAnnotations;
using Core.Contracts;
using Core.Exceptions;
using Core.Models;

namespace Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository repository;

    public AuthorService(IAuthorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<AuthorModel> AddAuthorAsync(AuthorModel author)
    {
        if (!Validator.ValidateAuthor(author))
            throw new NotValidModelException("Введите имя автора");
        
        await repository.AddAuthorAsync(author);
        
        return author;
    }

    public async Task<AuthorModel> GetByIdAsync(Guid authorId)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author.Id == Guid.Empty)
            throw new NotFoundException("Автор не найден");

        return author;
    }

    public async Task<List<AuthorModel>> GetAuthorsAsync(int skip, int take)
    {
        var authors = await repository.GetAuthorsAsync(skip, take);
        
        return authors;
    }

    public async Task<AuthorModel> UpdateAuthorAsync(AuthorModel author)
    {
        var authorFromDb = await repository.GetByIdAsync(author.Id);
        if (authorFromDb.Id == Guid.Empty)
            throw new NotFoundException("Автора не существует");
        
        await repository.UpdateAuthorAsync(author);

        return author;
    }

    public async Task<List<AuthorModel>> GetFamousAuthor()
    {
        var authors = await repository.GetFamousAuthor();
        return authors;
    }
}