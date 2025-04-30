namespace AdessoWorldLeague.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Team> Teams { get; set; } = new List<Team>();
} 