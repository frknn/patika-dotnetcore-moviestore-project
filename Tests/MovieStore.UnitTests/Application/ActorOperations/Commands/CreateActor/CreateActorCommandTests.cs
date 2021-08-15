using AutoMapper;
using MovieStore.DBOperations;
using TestSetup;
using Xunit;

namespace Application.ActorOperations.Commands.CreateActor
{
  public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateActorCommandTests(CommonTestFixture testFixture)
    {
      _dbContext = testFixture.Context;
      _mapper = testFixture.Mapper;
    }


  }
}