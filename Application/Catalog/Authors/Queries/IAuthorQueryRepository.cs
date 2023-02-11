using Application.Common.Contracts;
using Application.Catalog.Authors.Queries.ResponseModels;
using Domain.Catalog.Models;
using Application.Common.Specifications;
using Application.Catalog.Authors.Queries.Details;

namespace Application.Catalog.Authors.Queries
{
    public interface IAuthorQueryRepository : IQueryRepository<Author>
    {
        Task<AuthorDetailsResponseModel?> GetDetails(
            int id, 
            CancellationToken cancellationToken = default);

        Task<int> GetTotal(
            //Specification<Author> specification,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<AuthorResponseModel>> GetAuthorsListing(
            //Specification<Author> specification,
            int skip = 0, 
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default);
    }
}
