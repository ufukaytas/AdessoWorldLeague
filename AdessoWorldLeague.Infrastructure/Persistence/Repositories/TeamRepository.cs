using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(AdessoDbContext context) : base(context) { }

    public async Task<List<Team>> GetAllWithCountryAsync()
    {
        return await _dbSet.Include(t => t.Country).ToListAsync();
    }
} 