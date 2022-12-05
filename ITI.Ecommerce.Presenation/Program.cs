

using ITI.Ecommerce.Services;
using Microsoft.Extensions.FileProviders;

public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<ICategoryServie, CategoryService>();
        builder.Services.AddTransient<ICustomerService, CustomerService>();
        builder.Services.AddTransient<IPaymentService, PaymentService>();
        builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
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