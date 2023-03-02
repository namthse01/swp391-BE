using Application.Features.Category.Queries.GetList;
using Application.Features.Field.Command.Add;
using Application.Features.Field.Queries.Detail;
using Application.Features.Field.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Constants;

namespace WebApi.Controllers.v1
{
    [Route(RouterConstants.Category)]
    public class CategoryController : BaseApiController
    {
        /// <summary>
        /// Get list category
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] CategoryGetListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
