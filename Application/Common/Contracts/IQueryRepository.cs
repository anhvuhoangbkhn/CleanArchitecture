using Domain.Common.Entities;

namespace Application.Common.Contracts
{
    public interface IQueryRepository<in TEntity> 
        where TEntity : IAggregateRoot
    {

    }
}
