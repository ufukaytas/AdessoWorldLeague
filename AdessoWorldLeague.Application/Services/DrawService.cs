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

        var groups = Enumerable.Range(0, groupCount)
                               .Select(i => new Group { GroupName = groupNames[i] })
                               .ToList();

        var rnd = new Random();
        var teamPool = new List<Team>(teams.OrderBy(_ => rnd.Next()));

        int roundCount = 32 / groupCount;

        for (int round = 0; round < roundCount; round++)
        {
            foreach (var group in groups)
            {
                var team = teamPool.FirstOrDefault(t => group.Teams.All(gt => gt.Country.Id != t.Country.Id));
                if (team == null)
                    throw new InvalidOperationException("Cannot find a valid team for group.");

                group.Teams.Add(team);
                teamPool.Remove(team);
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
} 