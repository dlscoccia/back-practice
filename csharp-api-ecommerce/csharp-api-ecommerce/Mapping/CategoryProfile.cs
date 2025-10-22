using AutoMapper;
using csharp_api_ecommerce.Models.Dtos;

namespace csharp_api_ecommerce.Mapping;

public class CategoryProfile : Profile
{
  public CategoryProfile()
  {
    CreateMap<Category, CategoryDto>().ReverseMap();
    CreateMap<Category, CreateCategoryDto>().ReverseMap();
  }
}
