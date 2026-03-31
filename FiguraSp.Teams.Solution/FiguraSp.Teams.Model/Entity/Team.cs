namespace FiguraSp.Teams.Model.Entity
{
    public class Team
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string City { get; set; }

        public required string Country { get; set; }
    }
}
