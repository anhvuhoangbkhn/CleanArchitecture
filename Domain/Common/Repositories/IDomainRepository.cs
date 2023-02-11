using Domain.Common.Entities;
using System.Net.Http.Headers;

namespace Domain.Common.Repositories
{
    public interface IDomainRepository<in TEntity> 
        where TEntity : IAggregateRoot
    {
        Task Save(
            TEntity entity, 
            CancellationToken cancellationToken);
    }
}
