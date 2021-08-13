using AutoMapper;
using MovieStore.Application.MovieOperations.Queries.GetMovieById;
using MovieStore.Application.MovieOperations.Queries.GetMovies;
using MovieStore.Common;
using MovieStore.Entities;

namespace BookStore.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (GenreEnum)src.GenreId));
      CreateMap<Movie, GetMovieByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (GenreEnum)src.GenreId));
    }
  }
}