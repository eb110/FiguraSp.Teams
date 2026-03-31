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
        //comes directly from the shared library, so it is protected by the jwt scheme, so we need to be authorized to access it
        public async Task<ActionResult<List<TeamResponseDto>>> GetAllRiders()
        {
            var teams = await teamService.GetTeams();
            return Ok(teams);
        }
    }
}
