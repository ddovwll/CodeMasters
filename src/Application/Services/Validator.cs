using Core.Models;

namespace Application.Services;

public static class Validator
{
    /// <summary>
    /// Валидация модели автора
    /// </summary>
    /// <param name="author"></param>
    /// <returns>bool - валидность модели</returns>
    public static bool ValidateAuthor(AuthorModel author)
    {
        return !string.IsNullOrWhiteSpace(author.Name);
    }
}