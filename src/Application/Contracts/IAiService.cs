using Core.Enums;

namespace Application.Contracts;

public interface IAiService
{
    Task<string> SendMessageAsync(string message);
    Task<string> SendMessageAsync(string message, GptModelsEnum model);
}