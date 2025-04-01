using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Areas.Identity.Data;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Stripe_Payment_API;

namespace WebApplication4
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

        
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<WebApplication4Context>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>().AddEntityFrameworkStores<WebApplication4Context>();
            builder.Services.AddControllersWithViews();



            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));
            var key = builder.Configuration.GetValue<string>("StripeSettings:SecretKey");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();



            DataForDataBase.AddData(app);
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();



                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

            }


            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();



                string adminID = "00000000000";
                string AdminPassword = "AdminPassword@2025";


                if (await userManager.FindByEmailAsync("Admin@Camp.co.nz") == null)
                {
                    var user = new User();
                    user.Id = adminID;
                    user.UserName = "Admin@Camp.co.nz";
                    user.Email = "Admin@Camp.co.nz";
                    user.CampId = 1;
                    

                    await userManager.CreateAsync(user, AdminPassword);
                    await userManager.AddToRoleAsync(user, "Admin");

                }




                app.Run();
            }
        }
    }
}