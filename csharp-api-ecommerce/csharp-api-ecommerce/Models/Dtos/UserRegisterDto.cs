using System;

namespace csharp_api_ecommerce.Models.Dtos;

public class UserRegisterDto
{
  public string? Id { set; get; }
  public required string Username { set; get; }
  public required string Password { set; get; }
  public string? Name { set; get; }
  public string? Role { set; get; }
}
