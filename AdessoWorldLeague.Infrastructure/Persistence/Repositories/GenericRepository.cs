using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly AdessoDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AdessoDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public virtual async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
    public virtual Task AddAsync(T entity) => _dbSet.AddAsync(entity).AsTask();
    public virtual Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
    public virtual Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
} 