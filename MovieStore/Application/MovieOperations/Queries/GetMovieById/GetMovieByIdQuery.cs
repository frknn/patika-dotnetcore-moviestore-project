using System;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.Queries.GetMovieById
{
  public class GetMovieByIdQuery
  {
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMovieByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public GetMovieByIdViewModel Handle()
    {
      Movie movie = _dbContext.Movies.Where(movie => movie.Id == Id && movie.isActive).SingleOrDefault();
      if (movie is null)
      {
        throw new InvalidOperationException("Film bulunamadı.");
      }
      GetMovieByIdViewModel movieVM = _mapper.Map<GetMovieByIdViewModel>(movie);
      return movieVM;
    }
  }

  public class GetMovieByIdViewModel
  {
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public int? DirectorId { get; set; }
    // public Director Director { get; set; }
    public int Price { get; set; }
  }
}