using FiguraSp.SharedLibrary.Responses;

namespace FiguraSp.Teams.Model.Responses
{
    public record TeamResponseDto : DefaultResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}
