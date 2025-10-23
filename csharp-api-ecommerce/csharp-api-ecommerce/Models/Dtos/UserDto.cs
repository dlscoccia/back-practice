using System;

namespace csharp_api_ecommerce.Models.Dtos;

public class UserDto
{
  public int Id { set; get; }
  public string? Name { set; get; }
  public string? Username { set; get; }
  public string? Password { set; get; }
  public string? Role { set; get; }
}
