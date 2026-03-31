using FiguraSp.Teams.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace FiguraSp.Teams.Model.Data
{
    public partial class TeamsDbContext(DbContextOptions<TeamsDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Team> Team { get; set; }

        public virtual async Task<T> GetFirstOrDefaultAsync<T>(IQueryable<T> query)
        {
            var entity = await query.FirstOrDefaultAsync();

            return entity!;
        }

        public virtual async Task<List<T>> GetEntitiesToListAsync<T>(IQueryable<T> query)
        {
            var entities = await query.ToListAsync();

            return entities;
        }
    }
}
