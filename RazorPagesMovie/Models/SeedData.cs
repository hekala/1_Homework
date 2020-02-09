using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Alice",
                        ReleaseDate = DateTime.Parse("2000-2-11"),
                        Genre = "Romantic Comedy",
                        Price = 2M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghosts ",
                        ReleaseDate = DateTime.Parse("1999-3-7"),
                        Genre = "Horror",
                        Price = 8M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghosts 2",
                        ReleaseDate = DateTime.Parse("2002-2-23"),
                        Genre = "Horror",
                        Price = 9M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Winter",
                        ReleaseDate = DateTime.Parse("1983-4-15"),
                        Genre = "Drama",
                        Price = 3M,
                        Rating = "G"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
