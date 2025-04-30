using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore; 
namespace AdessoWorldLeague.Infrastructure.Persistence.Context;

public static class SeedData
{
    public static async Task EnsureSeededAsync(AdessoDbContext context)
    {
        if (await context.Teams.AnyAsync()) return;

        var countries = new List<Country>
        {
            new() { Id = 1, Name = "Türkiye" },
            new() { Id = 2, Name = "Almanya" },
            new() { Id = 3, Name = "Fransa" },
            new() { Id = 4, Name = "Hollanda" },
            new() { Id = 5, Name = "Portekiz" },
            new() { Id = 6, Name = "İtalya" },
            new() { Id = 7, Name = "İspanya" },
            new() { Id = 8, Name = "Belçika" }
        };

        var teams = new List<Team>
        {
            new("Adesso İstanbul", countries[0]),
            new("Adesso Ankara", countries[0]),
            new("Adesso İzmir", countries[0]),
            new("Adesso Antalya", countries[0]),

            new("Adesso Berlin", countries[1]),
            new("Adesso Frankfurt", countries[1]),
            new("Adesso Münih", countries[1]),
            new("Adesso Dortmund", countries[1]),

            new("Adesso Paris", countries[2]),
            new("Adesso Marsilya", countries[2]),
            new("Adesso Nice", countries[2]),
            new("Adesso Lyon", countries[2]),

            new("Adesso Amsterdam", countries[3]),
            new("Adesso Rotterdam", countries[3]),
            new("Adesso Lahey", countries[3]),
            new("Adesso Eindhoven", countries[3]),

            new("Adesso Lisbon", countries[4]),
            new("Adesso Porto", countries[4]),
            new("Adesso Braga", countries[4]),
            new("Adesso Coimbra", countries[4]),

            new("Adesso Roma", countries[5]),
            new("Adesso Milano", countries[5]),
            new("Adesso Venedik", countries[5]),
            new("Adesso Napoli", countries[5]),

            new("Adesso Sevilla", countries[6]),
            new("Adesso Madrid", countries[6]),
            new("Adesso Barselona", countries[6]),
            new("Adesso Granada", countries[6]),

            new("Adesso Brüksel", countries[7]),
            new("Adesso Brugge", countries[7]),
            new("Adesso Gent", countries[7]),
            new("Adesso Anvers", countries[7])
        };

        await context.Countries.AddRangeAsync(countries);
        await context.Teams.AddRangeAsync(teams);
        await context.SaveChangesAsync();
    }
}