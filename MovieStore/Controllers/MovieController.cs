using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.BookOperations.Queries.GetBookById;
using MovieStore.Application.MovieOperations.Queries.GetMovieById;
using MovieStore.Application.MovieOperations.Queries.GetMovies;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
  [ApiController]
  [Route("[Controller]s")]
  public class MovieController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public MovieController(IMovieStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
      GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
      List<MoviesViewModel> result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
      GetMovieByIdQuery query = new GetMovieByIdQuery(_context, _mapper);
      query.Id = id;

      GetMovieByIdQueryValidator validator = new GetMovieByIdQueryValidator();
      validator.ValidateAndThrow(query);

      GetMovieByIdViewModel result = query.Handle();

      return Ok(result);
    }
  }
}
