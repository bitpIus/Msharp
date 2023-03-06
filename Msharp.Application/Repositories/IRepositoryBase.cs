using System.Linq.Expressions;

namespace Msharp.Application.Repositories;

public interface IRepositoryBase<T> where T : class
{
    IEnumerable<T> FindAll(bool trackChanges);
    IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}