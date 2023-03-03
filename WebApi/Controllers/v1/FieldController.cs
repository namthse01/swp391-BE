using Application.Features.Field.Command.Add;
using Application.Features.Field.Queries.Detail;
using Application.Features.Field.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebApi.Constants;

namespace WebApi.Controllers.v1
{
    [Route(RouterConstants.Field)]
    public class FieldController : BaseApiController
    {
        /// <summary>
        /// Get list field
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] FieldGetListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new FieldDetailQuery() { Id = id }));
        }

        /// <summary>
        /// Create a new field
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FieldCreateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FieldCreateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}