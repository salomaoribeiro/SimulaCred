using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimulaCred.Application.Interfaces.Repositories;
using SimulaCred.Domain.Entities;

namespace SimulaCred.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken, 
        Expression<Func<T, bool>>? expression = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params Expression<Func<T, object>>[]? includeProperties)
    {
        IQueryable<T> query = _dbSet;
        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if (includeProperties is not null)
        {
            foreach (var include in includeProperties)
                query = query.Include(include);
        }

        if (orderBy is not null)
            query = orderBy(query);
        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }
}