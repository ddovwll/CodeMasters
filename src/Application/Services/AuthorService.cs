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
    /// <summary>
    /// Добавление автора в БД
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> AddAuthorAsync(AuthorModel author)
    {
        if (!Validator.ValidateAuthor(author))
            throw new NotValidModelException("Введите имя автора");
        
        await repository.AddAuthorAsync(author);
        
        return author;
    }
    /// <summary>
    /// Поиск автора по ID
    /// </summary>
    /// <param name="authorId">Id</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> GetByIdAsync(Guid authorId)
    {
        var author = await repository.GetByIdAsync(authorId);

        if (author.Id == Guid.Empty)
            throw new NotFoundException("Автор не найден");

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
        var authors = await repository.GetAuthorsAsync(skip, take);
        
        return authors;
    }
    /// <summary>
    /// Обновление данных обавторе
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    public async Task<AuthorModel> UpdateAuthorAsync(AuthorModel author)
    {
        var authorFromDb = await repository.GetByIdAsync(author.Id);
        if (authorFromDb.Id == Guid.Empty)
            throw new NotFoundException("Автора не существует");
        
        await repository.UpdateAuthorAsync(author);

        return author;
    }
    /// <summary>
    /// Получение списка всех известных людей
    /// </summary>
    /// <returns>List of AuthorModel</returns>
    public async Task<List<AuthorModel>> GetFamousAuthor()
    {
        var authors = await repository.GetFamousAuthor();
        return authors;
    }
}