using Skn.Domain.Commons;
using Skn.DataAccess.Contexts;
using System.Linq.Expressions;
using Skn.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Skn.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> dbSet;
    private readonly AppDbContext appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = this.appDbContext.Set<T>();
    }

    public async ValueTask<T> CreateAsync(T entity)
    {
        await this.dbSet.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async ValueTask<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> entities = expression == null ? this.dbSet.AsQueryable() : this.dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracked = true)
    {
        IQueryable<T> entities = expression == null ? this.dbSet.AsQueryable()
            : this.dbSet.Where(expression).AsQueryable();

        entities = isTracked ? entities.AsNoTracking() : entities;

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }
    
    public async ValueTask<bool> SaveAsync()
    {
        var rowsAffetted = await this.appDbContext.SaveChangesAsync();
        return rowsAffetted > 0;
    }
}
