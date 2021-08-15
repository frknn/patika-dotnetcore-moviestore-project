using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.MovieOperations.Commands.AddActor;
using MovieStore.DBOperations;
using MovieStore.Entities;
using TestSetup;
using Xunit;

namespace Application.MovieOperations.Commands.AddActor
{
  public class AddActorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly MovieStoreDbContext _dbContext;
    public AddActorCommandTests(CommonTestFixture testFixture)
    {
      _dbContext = testFixture.Context;
    }

    [Fact]
    public void WhenGivenMovieIsNotFound_Handle_ThrowsInvalidOperationException()
    {
      // Arrange
      AddActorCommand command = new AddActorCommand(_dbContext);
      command.Id = 999;
      command.Model = new AddActorModel() { ActorId = 1 };

      // Act & Assert
      FluentActions
        .Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>()
        .And
        .Message.Should().Be("Film bulunamadı.");
    }

    [Fact]
    public void WhenGivenActorIsNotFound_Handle_ThrowsInvalidOperationException()
    {
      // Arrange
      AddActorCommand command = new AddActorCommand(_dbContext);
      command.Id = 1;
      command.Model = new AddActorModel() { ActorId = 999 };

      // Act & Assert
      FluentActions
        .Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>()
        .And
        .Message.Should().Be("Oyuncu bulunamadı.");
    }

    [Fact]
    public void WhenGivenActorIsAlreadyPlayingInGivenMovie_Handle_ThrowsInvalidOperationException()
    {
      // Arrange
      AddActorCommand command = new AddActorCommand(_dbContext);
      command.Id = 3;
      command.Model = new AddActorModel() { ActorId = 3 };

      // Act & Assert
      FluentActions
        .Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>()
        .And
        .Message.Should().Be("Bu oyuncu zaten bu filmde oynuyor.");
    }

    [Fact]
    public void WhenValidInputsAreGivenMovie_Actor_ShouldBeAddedToTheMovie()
    {
      // Arrange
      AddActorCommand command = new AddActorCommand(_dbContext);
      command.Id = 1;
      command.Model = new AddActorModel() { ActorId = 3 };

      // Act
      FluentActions.Invoking(() => command.Handle()).Invoke();

      // Assert
      Movie movie = _dbContext.Movies.Include(movie => movie.Actors).SingleOrDefault(movie => movie.Id == command.Id);
      bool hasNewActor = movie.Actors.Any(actor => actor.Id == command.Model.ActorId); 
      hasNewActor.Should().BeTrue();

    }

  }
}