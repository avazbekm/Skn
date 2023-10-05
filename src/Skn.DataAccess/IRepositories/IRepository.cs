using Skn.Domain.Commons;
using System.Linq.Expressions;

namespace Skn.DataAccess.IRepositories;

public interface IRepository<T> where T : Auditable
{
     ValueTask<T> CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> SelectAll(
        Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracked = true);
    ValueTask<bool> SaveAsync();
}
