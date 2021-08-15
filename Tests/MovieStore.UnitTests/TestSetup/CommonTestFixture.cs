using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieStore.Common;
using MovieStore.DBOperations;

namespace TestSetup
{
  public class CommonTestFixture
  {
    public MovieStoreDbContext Context { get; set; }
    public IMapper Mapper { get; set; }
    public CommonTestFixture()
    {
      var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
      Context = new MovieStoreDbContext(options);
      Context.Database.EnsureCreated();
      Context.AddDirectors();
      Context.AddActors();
      Context.AddCustomers();
      Context.SaveChanges();

      Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
    }
  }
}