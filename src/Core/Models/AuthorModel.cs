namespace Core.Models;

public class AuthorModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public string? Vocabulary { get; set; }
    public string? Specialization { get; set; }
    public string? Tone { get; set; }
    public bool IsFamous { get; set; }
}