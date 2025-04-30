using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Persistence.Context;

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class DrawRepository : GenericRepository<Draw>, IDrawRepository
{
    public DrawRepository(AdessoDbContext context) : base(context) { }
} 