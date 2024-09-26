using Core.Models;

namespace Core.Contracts;

public interface IAnalyticsService
{
    /// <summary>
    /// Возвращает аналитику данного текста
    /// </summary>
    /// <param name="text">текст</param>
    /// <returns>AnalyticsModel</returns>
    Task<AnalyticsModel> GetAnalyticsAsync(string text);
}