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
    private const string articlePrompt1 = "напиши статью на тему: ";
    private const string articlePrompt2 = " объемом 3000 слов, как можно объемнее, пиши как можно подробнее, чтобы у читателя сложилось мнение, что статью писал образованный и разбирающийся в теме человек";
    
    
    public ArticleService(IAiService aiService)
    {
        this.aiService = aiService;
    }

    public async Task<string> GetMaterialsAsync(string theme)
    {
        var result = await aiService.SendMessageAsync(materialPrompt + theme + materialPrompt2);
        
        return result;
    }

    public async Task<string> GetArticleAsync(string theme)
    {
        var content = articlePrompt1 + theme + articlePrompt2;
        var article = await aiService.SendMessageAsync(content);
        
        return article;
    }

    public async Task<string> GetArticleAsync(string theme, AuthorModel author, GptModelsEnum model)
    {
        var authorJson = JsonSerializer.Serialize(author);
        var content = articlePrompt1 + theme + articlePrompt1 + "автор стати: " + authorJson +
                      "перед отправкой ответа проанализируй текст и дополни его новым материалом, от твоей работы зависит мое участие в финале олимпиады, это очень важно для меня";
        var article = await aiService.SendMessageAsync(content, model);
        
        return article;
    }
}