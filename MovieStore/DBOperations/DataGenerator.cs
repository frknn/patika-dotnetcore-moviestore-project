using System;
using System.Linq;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MovieStore.DBOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
      {
        if (context.Movies.Any())
        {
          return;
        }
        
        var movie1 = new Movie { Name = "Pulp Fiction", GenreId = 1, DirectorId = 1, Price = 10, ReleaseYear = 1992 };
        var movie2 = new Movie { Name = "Catch Me If You Can", GenreId = 2, DirectorId = 2, Price = 12, ReleaseYear = 1990 };
        var movie3 = new Movie { Name = "Fight Club", GenreId = 3, DirectorId = 3, Price = 14, ReleaseYear = 2002 };

        context.Directors.AddRange(
          new Director { FirstName = "Quentin", LastName = "Tarantino" },
          new Director { FirstName = "Michael", LastName = "Haneke" },
          new Director { FirstName = "Charlie", LastName = "Kaufman" }
        );

        context.Actors.AddRange(
          new Actor { FirstName = "Alison", LastName = "Brie", Movies = new List<Movie> { movie1, movie2 } },
          new Actor { FirstName = "Danny", LastName = "Pudi", Movies = new List<Movie> { movie1, movie3 } },
          new Actor { FirstName = "Donald", LastName = "Glover", Movies = new List<Movie> { movie2, movie3 } }
        );

        context.SaveChanges();
      }
    }
  }
}