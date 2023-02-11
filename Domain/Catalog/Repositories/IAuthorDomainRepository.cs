using Domain.Catalog.Models;
using Domain.Common.Repositories;
using System.Net.Http.Headers;

namespace Domain.Catalog.Repositories
{
    public interface IAuthorDomainRepository : IDomainRepository<Author>
    {
        Task<Author?> FindById(int id, CancellationToken cancellationToken= default);
        Task<Author?> FindByName(string name, CancellationToken cancellationToken = default);
        Task<bool> DeleteById(int id, CancellationToken cancellationToken= default);
    }
}
