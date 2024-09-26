namespace Core.Models;

public class ArticleModel
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Имя автора
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Ссылка
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// дата публикации
    /// </summary>
    public DateTime? PublishedAt { get; set; }
}