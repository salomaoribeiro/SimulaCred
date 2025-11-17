using System.Linq.Expressions;
using SimulaCred.Domain.Entities;

namespace SimulaCred.Application.Interfaces.Repositories;

public interface IBaseRepository<T> where T: BaseEntity
{
    Task AddAsync(T entity,  CancellationToken cancellationToken);
    
    Task UpdateAsync(T entity,  CancellationToken cancellationToken);
    
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params Expression<Func<T, object>>[]? includeProperties);
}