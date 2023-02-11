using Application.Catalog.Authors.Queries.Details;
using Application.Catalog.Authors.Queries.ResponseModels;
using Application.Catalog.Authors.Queries.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers.Catalog
{
    public class AuthorsController : APIController
    {
        [HttpGet]
        //[AllowAnonymous]
        public async Task<ActionResult<AuthorsSearchResponseModel>> Search(
        [FromQuery] AuthorsSearchQuery query)
        {
            return await this.Send(query);
        }

        [HttpGet]
        [Route(Id)]
        //[AllowAnonymous]
        public async Task<ActionResult<AuthorDetailsResponseModel?>> Details(
            [FromRoute] AuthorDetailsQuery query)
            => await this.Send(query);
    }
}
