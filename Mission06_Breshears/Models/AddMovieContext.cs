using Microsoft.EntityFrameworkCore;

namespace Mission06_Breshears.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options) //Constructor
        {

        }

        public DbSet<AddMovie> AddMovie { get; set; }
    }
}
