using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.BookOperations.Queries.GetBookById;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
using MovieStore.Application.MovieOperations.Commands.DeleteMovie;
using MovieStore.Application.MovieOperations.Commands.UpdateMovie;
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

    [HttpPost]
    public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
    {
      CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
      command.Model = newMovie;

      CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
      validator.ValidateAndThrow(command);

      command.Handle();

      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updatedMovie)
    {
      UpdateMovieCommand command = new UpdateMovieCommand(_context);

      command.Id = id;
      command.Model = updatedMovie;
      UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
      DeleteMovieCommand command = new DeleteMovieCommand(_context);

      command.Id = id;
      DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
      validator.ValidateAndThrow(command);
      command.Handle();

      return Ok();
    }
  }
}
