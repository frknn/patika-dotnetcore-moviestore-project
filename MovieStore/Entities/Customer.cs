using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
  public class Customer
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
  }
}