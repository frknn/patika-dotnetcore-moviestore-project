using FluentValidation;
using MovieStore.Application.MovieOperations.Queries.GetMovieById;

namespace MovieStore.Application.BookOperations.Queries.GetBookById
{
  public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
  {
    public GetMovieByIdQueryValidator()
    {
      RuleFor(query => query.Id).GreaterThan(0);
    }
  }
}