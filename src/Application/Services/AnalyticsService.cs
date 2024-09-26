using Core.Contracts;
using Core.Models;

namespace Application.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly char[] separators = new char[]
    {
        ' ',
        ',',
        '.',
        ';',
        ':',
        '!',
        '?',
        '-',
        '"',
        '\'',
        '«',
        '»',
        '„',
        '“',
        '(',
        ')',
        '[',
        ']',
        '{',
        '}',
        '/',
        '\\',
        '&',
        '%',
        '*',
        '+',
        '=',
        '_',
        '|',
        '\n',
        '\t',
        '\r'
    };

    /// <summary>
    /// Получение аналитики текста
    /// </summary>
    /// <param name="text">текст</param>
    /// <returns>AnalyticsModel</returns>
    public async Task<AnalyticsModel> GetAnalyticsAsync(string text)
    {
        var analytics = new AnalyticsModel()
        {
            Words = (await TextToDict(text)).OrderByDescending(w => w.Value).ToDictionary(),
            SymbolsCount = CountSymbols(text),
            WordsCount = CountWords(text)
        };

        return analytics;
    }

    /// <summary>
    /// Подсчет количества слов
    /// </summary>
    /// <param name="text">текст</param>
    /// <returns>int</returns>
    private int CountWords(string text)
    {
        var count = text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        return count;
    }

    /// <summary>
    /// Преобразование текста в отсортированный словарь
    /// </summary>
    /// <param name="text">текст</param>
    /// <returns>Dictionary (string, int)</returns>
    private Task<Dictionary<string, int>> TextToDict(string text)
    {
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var countedWords = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (word.Length > 2 && char.IsLetter(word.First()))
            {
                countedWords.TryAdd(word.ToLower(), 0);
                countedWords[word.ToLower()]++;
            }
        }

        return Task.FromResult(countedWords);
    }

    /// <summary>
    /// Подсчет количества символов в тексте
    /// </summary>
    /// <param name="text">текст</param>
    /// <returns>int</returns>
    private int CountSymbols(string text)
    {
        var symbolCount = text.Length;
        return symbolCount;
    }
}