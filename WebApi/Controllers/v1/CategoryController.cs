using Application.Features.Category.Command.Add;
using Application.Features.Category.Command.Update;
using Application.Features.Category.Queries.Detail;
using Application.Features.Category.Queries.GetList;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new CategoryDetailQuery() { Id = id }));
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
