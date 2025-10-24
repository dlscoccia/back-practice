using System;
using Microsoft.AspNetCore.Identity;

namespace csharp_api_ecommerce.Models;

public class ApplicationUser : IdentityUser
{
  public string? Name { set; get; }
}
