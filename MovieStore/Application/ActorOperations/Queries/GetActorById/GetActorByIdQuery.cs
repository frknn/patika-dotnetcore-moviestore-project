using System;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.ActorOperations.Queries.GetActorById
{
  public class GetActorByIdQuery
  {
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public GetActorByIdViewModel Handle()
    {
      Actor actor = _dbContext.Actors.Where(actor => actor.Id == Id).SingleOrDefault();
      if (actor is null)
      {
        throw new InvalidOperationException("Oyuncu bulunamadı.");
      }
      GetActorByIdViewModel actorVM = _mapper.Map<GetActorByIdViewModel>(actor);
      return actorVM;
    }
  }

  public class GetActorByIdViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}