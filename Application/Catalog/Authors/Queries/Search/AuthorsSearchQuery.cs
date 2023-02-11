using Application.Catalog.Authors.Queries.ResponseModels;
using Application.Common.Specifications;
using MediatR;

namespace Application.Catalog.Authors.Queries.Search
{
    public class AuthorsSearchQuery : IRequest<AuthorsSearchResponseModel>
    {
        private const int AuthorsPerPage = 10;
        public string? Name { get; init; }
        public int Page { get; init; } = 1;

        public class AuthorsSearchQueryHandler : IRequestHandler< AuthorsSearchQuery, 
            AuthorsSearchResponseModel >
        {
            private readonly IAuthorQueryRepository authorRepository;
            public AuthorsSearchQueryHandler(
                IAuthorQueryRepository authorRepository)
            {
                this.authorRepository = authorRepository;
            }

            public async Task<AuthorsSearchResponseModel> Handle(AuthorsSearchQuery request, CancellationToken cancellationToken)
            {
                //var specification = this.GetAuthorSpecification(request);

                var skip = (request.Page - 1) * AuthorsPerPage;
                var authorsListing = await this.authorRepository.GetAuthorsListing(
                //specification,
                skip,
                take: AuthorsPerPage,
                cancellationToken);

                var totalAuthors = await this.authorRepository.GetTotal(
                    //specification,
                    cancellationToken);

                var totalPages = (int)Math.Ceiling((double)totalAuthors / AuthorsPerPage);

                return new AuthorsSearchResponseModel(authorsListing, request.Page, totalPages);
            }
        }
    }
}
