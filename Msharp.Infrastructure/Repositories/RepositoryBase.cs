using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Msharp.Application.Repositories;
using Msharp.Infrastructure.Context;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual IEnumerable<T> FindAll(bool trackChanges) =>
        trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

    public virtual IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        trackChanges ? _context.Set<T>().Where(expression) : _context.Set<T>().Where(expression).AsNoTracking();

    public virtual void Create(T entity) => _context.Set<T>().Add(entity);

    public virtual void Update(T entity) => _context.Set<T>().Update(entity);

    public virtual void Delete(T entity) => _context.Set<T>().Remove(entity);
}