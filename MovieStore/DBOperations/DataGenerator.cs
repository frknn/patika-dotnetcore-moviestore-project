using System;
using System.Linq;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        context.Movies.AddRange(
          new Movie { Name = "Pulp Fiction", GenreId = 1, DirectorId = 1, Price = 10, ReleaseYear = 1992 },
          new Movie { Name = "Catch Me If You Can", GenreId = 2, DirectorId = 2, Price = 12, ReleaseYear = 1990 },
          new Movie { Name = "Fight Club", GenreId = 3, DirectorId = 3, Price = 14, ReleaseYear = 2002 }
        );

        context.SaveChanges();
      }
    }
  }
}