using FiguraSp.Teams.Model.Entity;
using FiguraSp.Teams.Model.Responses;

namespace FiguraSp.Teams.Model.Extensions
{
    public static class TeamExtension
    {
        public static TeamResponseDto ToTeamResponseDto(this Team team)
        {
            TeamResponseDto teamResponseDto = new()
            {
                Id = team.Id,
                Name = team.Name,
                City = team.City,
                Country = team.Country,
                Success = true
            };

            return teamResponseDto;
        }
    }
}
