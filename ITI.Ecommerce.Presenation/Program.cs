using ITI.Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace ITI.Ecommerce.Presenation
{
    public class Program
    {
        public static int Main()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;initial catalog = ITI.EcommerceDB; integrated security = true;");
            });

            builder.Services.AddIdentity<Customer, IdentityRole>
               ().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();


            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters = string.Empty;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });




            var app = builder.Build();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/Content",
                FileProvider = new PhysicalFileProvider
                (Path.Combine(Directory.GetCurrentDirectory(),
                "Content"))
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute("main", "{controller=User}/{action=SignIn}");

            app.Run();

            return 0;
        }
    }
}