using System;
using System.Linq;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
  public class DeleteDirectorCommand
  {
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Handle()
    {
      Director director = _dbContext.Directors.SingleOrDefault(director => director.Id == Id);
      if (director is null)
      {
        throw new InvalidOperationException("Yönetmen bulunamadı.");
      }

      _dbContext.Directors.Remove(director);
      _dbContext.SaveChanges();
    }
  }
}