using FiguraSp.SharedLibrary.Responses;
using FiguraSp.Teams.Model.Data;
using FiguraSp.Teams.Model.Entity;
using FiguraSp.Teams.Model.Extensions;
using FiguraSp.Teams.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace FiguraSp.Teams.Service.Services
{
    public class TeamService(TeamsDbContext context) : ITeamService
    {
        public async Task<DefaultResponse> CheckTeamsById(List<Guid> ids)
        {
            if(ids.Count < 2)
            {
                return new() { Errors = ["corrupted number of ids"] };
            }

            var numberOfDuplicates = ids.Count - ids.Distinct().ToList().Count;
            if (numberOfDuplicates > 0)
            {
                return new() { Errors = ["duplicated ids"] };
            }

            IQueryable<Team> query = context.Team.Where(x => ids.Contains(x.Id)).AsQueryable().AsNoTracking();
            var check = await context.GetEntitiesToListAsync(query);
            if(check.Count != ids.Count)
            {
                return new() { Errors = ["Corrupted set of ids"] };
            }
            
            return new() { Success = true };
        }

        public async Task<TeamResponseDto> GetTeamById(Guid id)
        {
            IQueryable<Team> query = context.Team.Where(x => x.Id.Equals(id)).AsQueryable().AsNoTracking();
            var team = await context.GetFirstOrDefaultAsync(query);
            if(team == null)
            {
                return new() { Errors = ["team doe's not exist"] };
            }
            return team.ToTeamResponseDto();
        }

        public async Task<List<TeamResponseDto>> GetTeams()
        {
            IQueryable<Team> query = context.Team.AsQueryable().OrderBy(x => x.City).AsNoTracking();
            var teams = await context.GetEntitiesToListAsync(query);
            List<TeamResponseDto> result = [.. teams.Select(x => x.ToTeamResponseDto())];
            return result;
        }
    }

    public interface ITeamService
    {
        public Task<List<TeamResponseDto>> GetTeams();
        public Task<DefaultResponse> CheckTeamsById(List<Guid> ids);

        public Task<TeamResponseDto> GetTeamById(Guid id);
    }
}
