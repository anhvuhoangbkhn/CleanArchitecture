using Application.Common.Mapping;
using Domain.Catalog.Models;

namespace Application.Catalog.Authors.Queries.ResponseModels
{
    public class AuthorResponseModel : IMapFrom<Author>
    {
        public string Name { get; private set; } = default!;
    }
}
