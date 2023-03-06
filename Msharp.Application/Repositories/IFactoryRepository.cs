using Msharp.Domain.Entities;

namespace Msharp.Application.Repositories;

public interface IFactoryRepository : IRepositoryBase<Factory>
{
    IEnumerable<Factory> GetAllFactories(bool trackChanges);
    Factory GetFactory(int Id, bool trackChanges);
}
