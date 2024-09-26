namespace Core.Models;

public class AuthorModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Биография
    /// </summary>
    public string? Biography { get; set; }
    /// <summary>
    /// Словарный запас
    /// </summary>
    public string? Vocabulary { get; set; }
    /// <summary>
    /// Специализация
    /// </summary>
    public string? Specialization { get; set; }
    /// <summary>
    /// Тон
    /// </summary>
    public string? Tone { get; set; }
    /// <summary>
    /// Является ли известным
    /// </summary>
    public bool IsFamous { get; set; }
}