using ApiEcommerce.Models.Dtos;
using AutoMapper;
using csharp_api_ecommerce.Models;
using csharp_api_ecommerce.Models.Dtos;

namespace csharp_api_ecommerce.Mapping;

public class UserProfile : Profile
{
  public UserProfile()
  {
    
  CreateMap<User, UserDto>().ReverseMap();
  CreateMap<User, CreateUserDto>().ReverseMap();
  CreateMap<User, UserLoginDto>().ReverseMap();
  CreateMap<User, UserLoginResponseDto>().ReverseMap();
  }
}
