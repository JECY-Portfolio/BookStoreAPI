using Book_Store_API.Data;
using Book_Store_API.Repository.BooksRepo;
using Book_Store_API.Repository.CategoriesRepo;
using Book_Store_API.Services.BookService;
using Book_Store_API.Services.CategoryServices;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection Add_Services(this IServiceCollection services, IConfiguration config)
    {
        services.ApplicationServices(config);
        services.AddDbContext(config);

        //services.AddTelegramServices(config);
        return services;
    }

    static void ApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        //Repositories
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();




        //Services
        services.AddScoped<IBooksService, BooksService>();
        services.AddScoped<ICategoryService, CategoryService>();
    }

    static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
