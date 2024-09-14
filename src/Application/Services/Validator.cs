using Core.Models;

namespace Application.Services;

public static class Validator
{
    public static bool ValidateAuthor(AuthorModel author)
    {
        return !string.IsNullOrWhiteSpace(author.Name);
    }
}