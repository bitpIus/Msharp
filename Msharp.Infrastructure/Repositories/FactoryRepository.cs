using Msharp.Application.Repositories;
using Msharp.Infrastructure.Context;
using Msharp.Domain.Entities;

public class FactoryRepository : RepositoryBase<Factory>, IFactoryRepository
{
    public FactoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<Factory> GetAllFactories(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(c => c.Id).ToList();

    public Factory GetFactory(int Id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(Id), trackChanges)
        .SingleOrDefault();
}
