namespace Core.Models;

public class AnalyticsModel
{
    /// <summary>
    ///  Словарь, содержащий количество слов, где ключ это слово, а значение - количество повторов
    /// </summary>
    public Dictionary<string, int> Words { get; set; } = new();

    /// <summary>
    /// Количество символов в тексте
    /// </summary>
    public int SymbolsCount { get; set; }

    /// <summary>
    /// Количество слов в тексте
    /// </summary>
    public int WordsCount { get; set; }
}