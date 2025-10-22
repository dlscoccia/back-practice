

using csharp_api_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
  
  public DbSet<Category> Categories { set; get; }
  public DbSet<Product> Products { set; get; }
}