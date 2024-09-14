using System.Text;
using System.Text.Json;
using Application.Contracts;
using Core.Enums;
using LikhodedDynamics.Sber.GigaChatSDK;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Infrastructure.Services;

public class AiService : IAiService
{
    private readonly string apiKey;

    public AiService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> SendMessageAsync(string message)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        var request = new Request("o1-mini", new(){new ("user", message)});
        
        var json = JsonSerializer.Serialize(request);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"https://api.proxyapi.ru/openai/v1/chat/completions", jsonContent);

        var qwe = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception();

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        
        JsonElement choicesElement = doc.RootElement.GetProperty("choices")[0];
        JsonElement messageElement = choicesElement.GetProperty("message");
        string content = messageElement.GetProperty("content").GetString();

        return content;
    }
    
    public async Task<string> SendMessageAsync(string message, GptModelsEnum model)
    {
        string gptModel = "o1-mini";
        switch (model)
        {
            case GptModelsEnum.O1_mini:
                gptModel = "o1-mini";
                break;
            case GptModelsEnum.Gpt_4o:
                gptModel = "gpt-4o";
                break;
            case GptModelsEnum.Gpt_40_mini:
                gptModel = "gpt-4o-mini";
                break;
            case GptModelsEnum.Gpt4_turbo:
                gptModel = "gpt-4-turbo";
                break;
            case GptModelsEnum.O1_preview:
                gptModel = "o1-preview";
                break;
        }
        
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        var request = new Request(gptModel, new(){new ("user", message)});
        
        var json = JsonSerializer.Serialize(request);
        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"https://api.proxyapi.ru/openai/v1/chat/completions", jsonContent);

        var qwe = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception();

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        
        JsonElement choicesElement = doc.RootElement.GetProperty("choices")[0];
        JsonElement messageElement = choicesElement.GetProperty("message");
        string content = messageElement.GetProperty("content").GetString();

        return content;
    }

    record Request(string model, List<Message> messages);
    record Message(string role, string content);
}