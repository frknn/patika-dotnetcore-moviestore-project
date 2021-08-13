using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.Queries.GetMovies
{
  public class GetMoviesQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public List<MoviesViewModel> Handle()
    {
      List<Movie> movies = _dbContext.Movies.OrderBy(movie => movie.Id).ToList<Movie>();
      List<MoviesViewModel> moviesVM = _mapper.Map<List<MoviesViewModel>>(movies);
      return moviesVM;
    }
  }

  public class MoviesViewModel
  {
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public int? DirectorId { get; set; }
    // public Director Director { get; set; }
    public int Price { get; set; }
  }
}