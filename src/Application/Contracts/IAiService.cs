using Core.Enums;

namespace Application.Contracts;

public interface IAiService
{
    /// <summary>
    /// Отправка сообщения LLM
    /// </summary>
    /// <param name="message">сообщение</param>
    /// <returns>string - ответ</returns>
    Task<string> SendMessageAsync(string message);
    /// <summary>
    /// Отправка сообщения LLM
    /// </summary>
    /// <param name="message">сообщение</param>
    /// <param name="model">модель LLM</param>
    /// <returns>string - ответ</returns>
    Task<string> SendMessageAsync(string message, GptModelsEnum model);
}