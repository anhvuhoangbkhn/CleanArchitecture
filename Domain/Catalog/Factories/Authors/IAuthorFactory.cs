using Domain.Catalog.Models;
using Domain.Common.Factories;

namespace Domain.Catalog.Factories.Authors
{
    public interface IAuthorFactory : IFactory<Author>
    {
        IAuthorFactory WithName(string name);
        IAuthorFactory WithDescription(string description);
    }
}
