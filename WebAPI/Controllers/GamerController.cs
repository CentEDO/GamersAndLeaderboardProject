using Application.Features.Gamers.Commands.CreateGamer;
using Application.Features.Gamers.Commands.DeleteGamer;
using Application.Features.Gamers.Commands.UpdateGamer;
using Application.Features.Gamers.Dtos;
using Application.Features.Gamers.Models;
using Application.Features.Gamers.Queries.GetListGamer;
using Application.Features.Gamers.Queries.GetListGamerByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateGamerCommand createGamerCommand)
        {
            CreatedGamerDto result = await Mediator.Send(createGamerCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGamerQuery getListGamerQuery = new() { PageRequest = pageRequest };
            GamerListModel result = await Mediator.Send(getListGamerQuery);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteGamerCommand deleteGamerCommand)
        {
            DeletedGamerDto result = await Mediator.Send(deleteGamerCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateGamerCommand updateGamerCommand)
        {
            UpdatedGamerDto result = await Mediator.Send(updateGamerCommand);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListDynamic([FromQuery]PageRequest pageRequest, [FromBody] Dynamic dynamic) 
        {
            GetListGamerByDynamicQuery getListGamerByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            GamerListModel result = await Mediator.Send(getListGamerByDynamicQuery);
            return Ok(result);

        }
    }
}
