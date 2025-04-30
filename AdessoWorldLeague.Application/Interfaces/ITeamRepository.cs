using AdessoWorldLeague.Domain.Entities;

namespace AdessoWorldLeague.Application.Interfaces;

public interface ITeamRepository : IRepository<Team>
{
    Task<List<Team>> GetAllWithCountryAsync();
} 