using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.ActorOperations.Queries.GetActors
{
  public class GetActorsQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public List<ActorsViewModel> Handle()
    {
      List<Actor> actors = _dbContext.Actors.OrderBy(actor => actor.Id).ToList<Actor>();
      List<ActorsViewModel> actorsVM = _mapper.Map<List<ActorsViewModel>>(actors);
      return actorsVM;
    }
  }

  public class ActorsViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}