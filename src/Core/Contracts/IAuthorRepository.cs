using Core.Models;

namespace Core.Contracts;

public interface IAuthorRepository
{
    Task<AuthorModel> AddAuthorAsync(AuthorModel author);
    Task<AuthorModel> GetByIdAsync(Guid authorId);
    Task<List<AuthorModel>> GetAuthorsAsync(int skip, int take);
    Task<AuthorModel> UpdateAuthorAsync(AuthorModel author);
    Task<List<AuthorModel>> GetFamousAuthor();
}