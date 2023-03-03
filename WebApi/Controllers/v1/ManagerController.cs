using Application.Features.Manager.Command.Add;
using Application.Features.Manager.Command.Update;
using Application.Features.Manager.Queries.Detail;
using Application.Features.Manager.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Constants;

namespace WebApi.Controllers.v1
{
    [Route(RouterConstants.Manager)]
    public class ManagerController : BaseApiController
    {
        /// <summary>
        /// Get list manager
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] ManagerGetListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new ManagerDetailQuery() { Id = id }));
        }

        /// <summary>
        /// Create a new manager
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ManagerCreateCommand command)
        {
              return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ManagerUpdateCommand command)
        {
              return Ok(await Mediator.Send(command));
        }
        
    }
}
