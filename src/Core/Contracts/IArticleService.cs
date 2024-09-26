using Core.Enums;
using Core.Models;

namespace Core.Contracts;

public interface IArticleService
{
    /// <summary>
    /// Возвращает материалы для статьи
    /// </summary>
    /// <param name="theme">тема</param>
    /// <returns>string - материалы</returns>
    Task<string> GetMaterialsAsync(string theme);
    /// <summary>
    /// Метод для получения статьи
    /// </summary>
    /// <param name="theme">тема</param>
    /// <param name="author">автор</param>
    /// <param name="model">модель LLM</param>
    /// <param name="language">язык текста</param>
    /// <returns>string - статья</returns>
    Task<string> GetArticleAsync(string theme, AuthorModel author, GptModelsEnum model, LanguagesEnum language);
}