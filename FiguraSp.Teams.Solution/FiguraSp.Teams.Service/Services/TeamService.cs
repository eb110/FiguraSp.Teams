using FiguraSp.Teams.Model.Data;
using FiguraSp.Teams.Model.Entity;
using FiguraSp.Teams.Model.Extensions;
using FiguraSp.Teams.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace FiguraSp.Teams.Service.Services
{
    public class TeamService(TeamsDbContext context) : ITeamService
    {
        public async Task<List<TeamResponseDto>> GetTeams()
        {
            IQueryable<Team> query = context.Team.AsQueryable().AsNoTracking();
            var teams = await context.GetEntitiesToListAsync(query);
            List<TeamResponseDto> result = [.. teams.Select(x => x.ToTeamResponseDto())];
            return result;
        }
    }

    public interface ITeamService
    {
        public Task<List<TeamResponseDto>> GetTeams();
    }
}
