using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieStore.DBOperations
{
  public interface IMovieStoreDbContext
  {
    public DbSet<Movie> Movies { get; set; }

    int SaveChanges();
  }
}