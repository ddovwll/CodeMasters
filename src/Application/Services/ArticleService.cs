using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Contracts;
using Core.Contracts;
using Core.Enums;
using Core.Models;

namespace Application.Services;

public class ArticleService : IArticleService
{
    private readonly IAiService aiService;
    private const string materialPrompt = "напиши список материалов для статьи на тему: ";
    private const string materialPrompt2 = " также можешь приложить ссылки на источники и предложить лиетратуру";
    private const string articlePrompt1 = "Напиши статью от лица ";
    private const string articlePrompt2 = " который является ";
    private const string articlePrompt3 = " Тема статьи: ";
    private const string articlePrompt4 = " Статья должна быть написана в стиле ";
    private const string articlePrompt5 = " Объем статьи: как можно больше, используй самоанализ";
    
    
    public ArticleService(IAiService aiService)
    {
        this.aiService = aiService;
    }
    /// <summary>
    /// Возвращает материалы для статьи
    /// </summary>
    /// <param name="theme">тема</param>
    /// <returns>string - материалы</returns>
    public async Task<string> GetMaterialsAsync(string theme)
    {
        var result = await aiService.SendMessageAsync(materialPrompt + theme + materialPrompt2);
        
        return result;
    }

    /// <summary>
    /// Метод для получения статьи
    /// </summary>
    /// <param name="theme">тема</param>
    /// <param name="author">автор</param>
    /// <param name="model">модель LLM</param>
    /// <param name="language">язык текста</param>
    /// <returns>string - статья</returns>
    public async Task<string> GetArticleAsync(string theme, AuthorModel author, GptModelsEnum model, LanguagesEnum language)
    {
        string lang = "Русский";
        switch (language)
        {
            case LanguagesEnum.Spanish:
                lang = "Испанский";
                break;
            case LanguagesEnum.English:
                lang = "Английский";
                break;
            case LanguagesEnum.Portuguese:
                lang = "Португальский";
                break;
            case LanguagesEnum.Russian:
                lang = "Русский";
                break;
        }
        
        var authorJson = JsonSerializer.Serialize(author);
        var content = articlePrompt1 + author.Name + articlePrompt2 + author.Biography + " " + author.Specialization + articlePrompt3 + theme + articlePrompt4 + author.Tone + articlePrompt5;
        var article = await aiService.SendMessageAsync(content, model);
        
        return article;
    }
}