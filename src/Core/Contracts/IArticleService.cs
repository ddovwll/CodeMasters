using Core.Enums;
using Core.Models;

namespace Core.Contracts;

public interface IArticleService
{
    Task<string> GetMaterialsAsync(string theme);
    Task<string> GetArticleAsync(string theme);
    Task<string> GetArticleAsync(string theme, AuthorModel author, GptModelsEnum model);
}