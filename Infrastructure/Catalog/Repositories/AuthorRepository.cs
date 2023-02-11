using Application.Catalog.Authors.Queries;
using Application.Catalog.Authors.Queries.Details;
using Application.Catalog.Authors.Queries.ResponseModels;
using AutoMapper;
using Domain.Catalog.Models;
using Domain.Catalog.Repositories;
using Infrastructure.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Catalog.Repositories
{
    internal class AuthorRepository : DataRepository<ICatalogDbContext, Author>,
        IAuthorDomainRepository,
        IAuthorQueryRepository
    {
        public AuthorRepository(
            ICatalogDbContext catalogDbContext, 
            IMapper mapper) 
            : base(catalogDbContext, mapper) { }
        public async Task<bool> DeleteById(
            int id, 
            CancellationToken cancellationToken = default)
        {
            var author = await this.Data.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            this.Data.Authors.Remove(author);
            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Author?> FindById(
            int id,
            CancellationToken cancellationToken = default)
            => await this.All()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<Author?> FindByName(
            string name, 
            CancellationToken cancellationToken = default)
                => await this.All()
                    .Where(a => a.Name == name)
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<IEnumerable<AuthorResponseModel>> GetAuthorsListing(
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => await this.Mapper.ProjectTo<AuthorResponseModel>(
                this.GetAuthorsQuery()
                .OrderBy(a => a.Name)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);
                

        public async Task<int> GetTotal(
            CancellationToken cancellationToken = default)
            => await this
            .GetAuthorsQuery()
            .CountAsync(cancellationToken);

        public async Task<AuthorDetailsResponseModel?> GetDetails(
            int id, 
            CancellationToken cancellationToken)
            => await this.Mapper.ProjectTo<AuthorDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(a => a.Id == id))
            .FirstOrDefaultAsync(cancellationToken);

        private IQueryable<Author> GetAuthorsQuery()
        => this.AllAsNoTracking();
    }
}
