namespace AdessoWorldLeague.Domain.Entities;

public class Draw
{
    public Draw() {}
    public Draw(string drawnBy, List<Group> groups)
    {
        DrawnBy = drawnBy;
        Groups = groups;
        Date = DateTime.UtcNow;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string DrawnBy { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public List<Group> Groups { get; set; } = new();
} 