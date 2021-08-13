using System;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.DirectorOperations.Queries.GetDirectorById
{
  public class GetDirectorByIdQuery
  {
    public int Id { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDirectorByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public GetDirectorByIdViewModel Handle()
    {
      Director director = _dbContext.Directors.Where(director => director.Id == Id).SingleOrDefault();
      if (director is null)
      {
        throw new InvalidOperationException("Yönetmen bulunamadı.");
      }
      GetDirectorByIdViewModel directorVM = _mapper.Map<GetDirectorByIdViewModel>(director);
      return directorVM;
    }
  }

  public class GetDirectorByIdViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}