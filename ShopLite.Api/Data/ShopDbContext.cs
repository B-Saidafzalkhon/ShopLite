using Microsoft.EntityFrameworkCore;
using ShopLite.Api.Entities;

namespace ShopLite.Api.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
    
    public DbSet<Category> Categories => Set<Category>();
}