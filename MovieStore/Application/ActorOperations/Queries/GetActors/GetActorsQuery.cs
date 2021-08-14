using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.ActorOperations.Queries.SharedViewModels;
using MovieStore.DBOperations;
using MovieStore.Entities;

namespace MovieStore.Application.ActorOperations.Queries.GetActors
{
  public class GetActorsQuery
  {
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public List<ActorsViewModel> Handle()
    {
      List<Actor> actors = _dbContext.Actors.Include(actor => actor.Movies.Where(movie => movie.isActive)).ThenInclude(movie => movie.Director).OrderBy(actor => actor.Id).ToList<Actor>();
      List<ActorsViewModel> actorsVM = _mapper.Map<List<ActorsViewModel>>(actors);

      // var customers = _dbContext.Customers.OrderBy(customer => customer.Id).Include(customer => customer.Orders);
      // foreach (var customer in customers)
      // {
      //   Console.WriteLine("Customer First Name: " + customer.FirstName);
      //   Console.WriteLine("Customer Last Name: " + customer.LastName);
      //   foreach (var order in customer.Orders)
      //   {
      //     Console.WriteLine("Order Movie Id: " + order.MovieId);
      //     Console.WriteLine("Order Price: " + order.Price);
      //     Console.WriteLine("Order Date: " + order.ProcessDate);
      //   }
      // }
      return actorsVM;
    }
  }

  public class ActorsViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ActedInMovieViewModel> Movies { get; set; }
  }

}