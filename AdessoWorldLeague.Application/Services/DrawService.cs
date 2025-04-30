using AdessoWorldLeague.Application.DTOs;
using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;

namespace AdessoWorldLeague.Application.Services;



public class DrawService : IDrawService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IDrawRepository _drawRepository;
    private static readonly string[] groupNames = { "A", "B", "C", "D", "E", "F", "G", "H" };

    public DrawService(ITeamRepository teamRepository, IDrawRepository drawRepository)
    {
        _teamRepository = teamRepository;
        _drawRepository = drawRepository;
    }

    public async Task<DrawResultDto> DrawGroupsAsync(int groupCount, string drawnBy)
    {
        if (groupCount != 4 && groupCount != 8)
            throw new ArgumentException("Group count must be 4 or 8.");

        var teams = await _teamRepository.GetAllWithCountryAsync();

        if (teams.Count != 32)
            throw new InvalidOperationException("There must be exactly 32 teams.");

        // Create groups by groupCount
        List<Group> groups = new();
            for (int i = 0; i < groupCount; i++)
                groups.Add(new Group { GroupName = $"Grup {groupNames[i]}" });

    
        var rnd = new Random();
        var selectedTeams = new HashSet<Guid>(); 
        var countries = teams.Select(t => t.Country).Distinct().ToList();

        int teamsPerGroup = groupCount == 4 ? 8 : 4;

        foreach (var group in groups)
        {
            foreach (var country in countries)
            {
                
                var availableTeams = teams
                    .Where(t => t.Country.Id == country.Id && !selectedTeams.Contains(t.Id))
                    .ToList();
 
                if (availableTeams.Count == 0)
                    continue;
 
                var team = availableTeams[rnd.Next(availableTeams.Count)];
                group.Teams.Add(team);
                selectedTeams.Add(team.Id);
 
                if (group.Teams.Count == teamsPerGroup)
                    break;
            }
        }
 
        var draw = new Draw
        {
            DrawnBy = drawnBy,
            Date = DateTime.UtcNow,
            Groups = groups
        };

        await _drawRepository.AddAsync(draw);
        await _drawRepository.SaveChangesAsync();

        return new DrawResultDto
        {
            DrawnBy = draw.DrawnBy,
            Date = draw.Date,
            Groups = draw.Groups.Select(g => new GroupDto
            {
                GroupName = g.GroupName,
                Teams = g.Teams.Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Country = t.Country.Name
                }).ToList()
            }).ToList()
        };
    }

    public async Task<List<DrawResultDto>> GetAllDrawsAsync()
    {
        // Eager load Groups and Teams (and Countries)
        var draws = await _drawRepository.GetAllAsync(); // You may need to add a custom method for eager loading

        return draws.Select(d => new DrawResultDto
        {
            DrawnBy = d.DrawnBy,
            Date = d.Date,
            Groups = d.Groups.Select(g => new GroupDto
            {
                GroupName = g.GroupName,
                Teams = g.Teams.Select(t => new TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Country = t.Country.Name
                }).ToList()
            }).ToList()
        }).ToList();
        
 
       
    }
} 