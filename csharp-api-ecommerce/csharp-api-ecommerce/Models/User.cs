using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_api_ecommerce.Models;

public class User
{
  [Key]
  public int Id { set; get; }
  public string? Name { set; get; }
  public string Username { set; get; } = string.Empty;
  public string? Password { set; get; }
  public string? Role { set; get; }
}
