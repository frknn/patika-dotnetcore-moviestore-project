using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStore.DBOperations;
using MovieStore.TokenOperations.Models;
using MovieStore.Application.CustomerOperations.Commands.RefreshToken;
using MovieStore.Application.CustomerOperations.Commands.CreateToken;
using MovieStore.Application.CustomerOperations.Commands.CreateCustomer;

namespace MovieStore.Controllers
{
  [ApiController]
  [Route("[Controller]s")]
  public class CustomerController : ControllerBase
  {
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
    {
      CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
      command.Model = newCustomer;
      command.Handle();

      return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] LoginModel loginInfo)
    {
      CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
      command.Model = loginInfo;
      Token token = command.Handle();

      return token;
    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
      RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
      command.RefreshToken = token;
      Token resultAccessToken = command.Handle();
      return resultAccessToken;
    }

  }
}