

using ITI.Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

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
        var app = builder.Build();
        app.UseStaticFiles(new StaticFileOptions()
        {
            RequestPath = "/Content",
            FileProvider = new PhysicalFileProvider
            (Path.Combine(Directory.GetCurrentDirectory(),
            "Content"))
        });
        app.MapControllerRoute("main", "{controller=Home}/{action=Index}");
        app.Run();

        return 0;
    }
}