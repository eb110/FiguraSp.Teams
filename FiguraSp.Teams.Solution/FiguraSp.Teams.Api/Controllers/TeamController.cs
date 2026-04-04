using FiguraSp.SharedLibrary.Responses;
using FiguraSp.Teams.Model.Entity;
using FiguraSp.Teams.Model.Responses;
using FiguraSp.Teams.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiguraSp.Teams.Api.Controllers
{
    [Route("api/[controller]")] // http://localhost:5003/api/team
    [ApiController]
    public class TeamController(ITeamService teamService) : ControllerBase
    {
        [HttpGet]
        [Route("Teams")]
        public async Task<ActionResult<List<TeamResponseDto>>> GetAllRiders()
        {
            var teams = await teamService.GetTeams();
            return Ok(teams);
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamResponseDto>>> GetRider(Guid id)
        {
            var response = await teamService.GetTeamById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        [Route("CheckTeams")]
        public async Task<ActionResult<DefaultResponse>> CheckTeamsById([FromBody] List<Guid> ids)
        {
            var response = await teamService.CheckTeamsById(ids);
            if(response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
