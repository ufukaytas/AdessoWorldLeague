namespace AdessoWorldLeague.Domain.Entities;

public class Country
{
    public int Id { get; set; } // örn: 1 - Turkey, 2 - Germany
    public string Name { get; set; } = null!;

    public ICollection<Team> Teams { get; set; } = new List<Team>();
} 