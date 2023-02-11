using Domain.Catalog.Models;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Catalog.Repositories
{
    internal interface ICatalogDbContext : IDbContext
    {
        //DbSet<Book> CatalogBooks { get; }

        DbSet<Author> Authors { get; }
    }
}
