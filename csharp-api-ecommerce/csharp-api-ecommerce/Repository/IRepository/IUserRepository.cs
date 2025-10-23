using ApiEcommerce.Models.Dtos;
using csharp_api_ecommerce.Models;
using csharp_api_ecommerce.Models.Dtos;

namespace csharp_api_ecommerce.Repository.IRepository;

public interface IUserRepository
{
  ICollection<User> GetUsers();

  User? GetUser(int id);

  bool IsUniqueUser(string username);

  Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);

  Task<User> Register(CreateUserDto createUserDto);
}
