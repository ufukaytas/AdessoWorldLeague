using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore; 

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class DrawRepository : GenericRepository<Draw>, IDrawRepository
{
    public DrawRepository(AdessoDbContext context) : base(context) { }

        public async Task<List<Draw>> GetAllWithGroupsAndTeamsAsync()
        {
            return await _context.Draws
                .Include(d => d.Groups)
                    .ThenInclude(g => g.Teams)
                        .ThenInclude(t => t.Country)
                .ToListAsync();
        }
} 