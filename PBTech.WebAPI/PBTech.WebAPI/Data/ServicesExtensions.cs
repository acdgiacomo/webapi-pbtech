using Microsoft.EntityFrameworkCore;

namespace PBTech.WebAPI.Data
{
    public static class ServicesExtensions
    {
        public static IServiceCollection DataSqlServices(this IServiceCollection services, string conn)
        {
            services.AddDbContext<UsuarioContext>(options =>
                options.UseSqlServer(conn,
                    query => query.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddScoped<UsuarioContext>();

            return services;
        }
    }
}