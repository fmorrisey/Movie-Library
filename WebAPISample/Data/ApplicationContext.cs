using Microsoft.EntityFrameworkCore;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            :base(options)
        {

        }
       
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .HasData(
               new Movie { MovieId = 1, Title = "The Departed", Genre = "Drama", Director = "Martin Scorsese", PosterImg = "https://www.joblo.com/assets/images/oldsite/posters/images/full/2008-dark_knight-5.jpg" },
               new Movie { MovieId = 2, Title = "The Dark Knight", Genre = "Drama", Director = "Christopher Nolan", PosterImg = "https://www.joblo.com/assets/images/oldsite/posters/images/full/2006-departed-9.jpg" },
               new Movie { MovieId = 3, Title = "Inception", Genre = "Drama", Director = "Christopher Nolan", PosterImg = "https://www.joblo.com/assets/images/oldsite/posters/images/full/inception-imax-poster0.jpg" },
               new Movie { MovieId = 4, Title = "Pineapple Express", Genre = "Comedy", Director = "David Gordon Green", PosterImg = "https://www.joblo.com/assets/images/oldsite/posters/images/full/2008-pineapple_express-4.jpg" },
               new Movie { MovieId = 5, Title = "Die Hard", Genre = "Action", Director = "John McTiernan", PosterImg = "https://www.joblo.com/assets/images/oldsite/posters/images/full/1988-die-hard-poster2.jpg" }
            );

        }

    }
}
