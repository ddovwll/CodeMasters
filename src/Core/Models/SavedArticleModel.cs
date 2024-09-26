namespace Core.Models;

public class SavedArticleModel
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя автора
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// Текст статьи
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public string Name{ get; set; }
}