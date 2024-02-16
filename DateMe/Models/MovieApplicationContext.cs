using Microsoft.EntityFrameworkCore;

namespace MovieDB.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
        }

        public DbSet<MovieApp> MovieApp { get; set; }
    }
}

