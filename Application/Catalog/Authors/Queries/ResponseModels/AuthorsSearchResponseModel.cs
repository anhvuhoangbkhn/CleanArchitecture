using Application.Common.Models;

namespace Application.Catalog.Authors.Queries.ResponseModels
{
    public class AuthorsSearchResponseModel : PaginatedResponseModel<AuthorResponseModel>
    {
        internal AuthorsSearchResponseModel(
            IEnumerable<AuthorResponseModel> models, 
            int page, 
            int totalPages)
            : base(models, page, totalPages)
        {

        }
    }
}
