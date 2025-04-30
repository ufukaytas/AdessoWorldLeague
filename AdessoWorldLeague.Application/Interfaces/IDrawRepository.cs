using AdessoWorldLeague.Domain.Entities;

namespace AdessoWorldLeague.Application.Interfaces;

public interface IDrawRepository : IRepository<Draw>
    {
        Task<List<Draw>> GetAllWithGroupsAndTeamsAsync();
    }