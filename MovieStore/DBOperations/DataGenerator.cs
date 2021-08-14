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

        var order1 = new Order { CustomerId = 1, MovieId = 1, Price = movie1.Price, ProcessDate = DateTime.Now.AddDays(-10) };
        var order2 = new Order { CustomerId = 1, MovieId = 1, Price = movie1.Price, ProcessDate = DateTime.Now.AddDays(-15) };
        var order3 = new Order { CustomerId = 1, MovieId = 3, Price = movie3.Price, ProcessDate = DateTime.Now.AddDays(-20) };
        var order4 = new Order { CustomerId = 2, MovieId = 1, Price = movie1.Price, ProcessDate = DateTime.Now.AddDays(-10) };
        var order5 = new Order { CustomerId = 2, MovieId = 2, Price = movie2.Price, ProcessDate = DateTime.Now.AddDays(-15) };
        var order6 = new Order { CustomerId = 2, MovieId = 3, Price = movie3.Price, ProcessDate = DateTime.Now.AddDays(-20) };
        var order7 = new Order { CustomerId = 3, MovieId = 1, Price = movie1.Price, ProcessDate = DateTime.Now.AddDays(-10) };
        var order8 = new Order { CustomerId = 3, MovieId = 2, Price = movie2.Price, ProcessDate = DateTime.Now.AddDays(-15) };
        var order9 = new Order { CustomerId = 3, MovieId = 3, Price = movie3.Price, ProcessDate = DateTime.Now.AddDays(-20) };

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

        context.Customers.AddRange(
          new Customer { FirstName = "Furkan", LastName = "Setbaşı", Email = "furkan@example.com", Password = "furkan123", Orders = new List<Order> { order1, order2, order3 } },
          new Customer { FirstName = "Hakan", LastName = "Çelik", Email = "hakan@example.com", Password = "hakan123", Orders = new List<Order> { order4, order5, order6 } },
          new Customer { FirstName = "Kemal", LastName = "Yalçın", Email = "kemal@example.com", Password = "kemal123", Orders = new List<Order> { order7, order8, order9 } }
        );

        context.SaveChanges();
      }
    }
  }
}