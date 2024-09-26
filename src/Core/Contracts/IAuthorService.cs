using Core.Models;

namespace Core.Contracts;

public interface IAuthorService
{
    /// <summary>
    /// Добавление автора в БД
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    Task<AuthorModel> AddAuthorAsync(AuthorModel author);
    /// <summary>
    /// Поиск автора по ID
    /// </summary>
    /// <param name="authorId">Id</param>
    /// <returns>AuthorModel</returns>
    Task<AuthorModel> GetByIdAsync(Guid authorId);
    /// <summary>
    /// Получение списка авторов
    /// </summary>
    /// <param name="skip">сколько пропустить эл-ов</param>
    /// <param name="take">сколько взять эл-ов</param>
    /// <returns>List of AuthorModel</returns>
    Task<List<AuthorModel>> GetAuthorsAsync(int skip, int take);
    /// <summary>
    /// Обновление данных обавторе
    /// </summary>
    /// <param name="author">автор</param>
    /// <returns>AuthorModel</returns>
    Task<AuthorModel> UpdateAuthorAsync(AuthorModel author);
    /// <summary>
    /// Получение списка всех известных людей
    /// </summary>
    /// <returns>List of AuthorModel</returns>
    Task<List<AuthorModel>> GetFamousAuthor();
}