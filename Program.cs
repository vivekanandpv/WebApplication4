using Microsoft.EntityFrameworkCore;
using WebApplication4.DAL;
using WebApplication4.Services;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<ProductCatalogContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
            });
            builder.Services.AddControllers();
            builder.Services.AddScoped<IProductService, ProductService>();
            
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}