namespace AdessoWorldLeague.Domain.Entities;

public class Team
{
    public Team() { }
    public Team(string name, Country country)
    {
        Name = name;
        Country = country;
        CountryId = country.Id;
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
} 