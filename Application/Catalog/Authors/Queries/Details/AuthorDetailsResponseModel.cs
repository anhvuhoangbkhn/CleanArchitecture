using Application.Catalog.Authors.Queries.ResponseModels;

namespace Application.Catalog.Authors.Queries.Details
{
    public class AuthorDetailsResponseModel : AuthorResponseModel
    {
        public string Description { get; private set; } = default!;
    }
}
