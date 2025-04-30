using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Persistence.Context;

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(AdessoDbContext context) : base(context) { }
} 