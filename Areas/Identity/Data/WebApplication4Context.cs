using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data;

public class WebApplication4Context : IdentityDbContext<IdentityUser>
{
    public WebApplication4Context(DbContextOptions<WebApplication4Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<WebApplication4.Models.Item> Item { get; set; } = default!;

    public DbSet<WebApplication4.Models.Category> Category { get; set; } = default!;

public DbSet<WebApplication4.Models.OrderItem> OrderItem { get; set; } = default!;

public DbSet<WebApplication4.Models.Order> Order { get; set; } = default!;

    public DbSet<WebApplication4.Models.Status> Status { get; set; } = default!;

public DbSet<WebApplication4.Models.Camp> Camp { get; set; } = default!;

    public DbSet<WebApplication4.Models.User> Users { get; set; } = default;

public DbSet<WebApplication4.Models.Stock> Stock { get; set; } = default!;




}
