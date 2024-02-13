using Blazor.Data.Entities.NewsEntities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<News> News { get; set; }

    }
}
