using System;
using System.Linq;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.ActorOperations.Commands.DeleteActor
{
  public class DeleteActorCommand
  {
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;

    public DeleteActorCommand(IMovieStoreDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Handle()
    {
      Actor actor = _dbContext.Actors.SingleOrDefault(actor => actor.Id == Id);
      if (actor is null)
      {
        throw new InvalidOperationException("Oyuncu bulunamadı.");
      }

      _dbContext.Actors.Remove(actor);
      _dbContext.SaveChanges();
    }
  }
}