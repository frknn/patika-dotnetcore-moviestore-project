using AutoMapper;
using MovieStore.Application.ActorOperations.Commands.CreateActor;
using MovieStore.Application.ActorOperations.Queries.GetActorById;
using MovieStore.Application.ActorOperations.Queries.GetActors;
using MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using MovieStore.Application.DirectorOperations.Queries.GetDirectorById;
using MovieStore.Application.DirectorOperations.Queries.GetDirectors;
using MovieStore.Application.MovieOperations.Commands.CreateMovie;
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
      CreateMap<CreateMovieModel, Movie>();
      CreateMap<Actor, ActorsViewModel>();
      CreateMap<Actor, GetActorByIdViewModel>();
      CreateMap<CreateActorModel, Actor>();
      CreateMap<Director, DirectorsViewModel>();
      CreateMap<Director, GetDirectorByIdViewModel>();
      CreateMap<CreateDirectorModel, Director>();
    }
  }
}