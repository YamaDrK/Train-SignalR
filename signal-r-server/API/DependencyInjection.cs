using API.Data;
using API.SignalR;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSignalR();

            return services;
        }

        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication UseApplicationHubs(this WebApplication app)
        {
            app.MapHub<ProductHub>("/productHub");

            return app;
        }
    }
}
