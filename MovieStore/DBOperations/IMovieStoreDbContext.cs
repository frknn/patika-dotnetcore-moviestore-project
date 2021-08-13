using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieStore.DBOperations
{
  public interface IMovieStoreDbContext
  {
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }

    int SaveChanges();
  }
}