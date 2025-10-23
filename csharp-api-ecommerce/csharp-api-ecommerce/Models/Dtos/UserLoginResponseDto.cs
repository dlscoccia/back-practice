using System;

namespace csharp_api_ecommerce.Models.Dtos;

public class UserLoginResponseDto
{
public UserRegisterDto? User { set; get; }
public string? Token { set; get; }
public string? Message { set; get; }
}
