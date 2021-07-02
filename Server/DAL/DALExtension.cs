using Microsoft.Extensions.DependencyInjection;
using DAL.UOW;
using DAL.Repertoire;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public static class DALExtension
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            // Ses propres services
            services.AddScoped<IDbSession, DbSession>(services => new DbSession(services.GetRequiredService<IConfiguration>(), "DefaultConnection"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Les Repertoires
            services.AddTransient<IIngredientRepertoire, IngredientRepertoire>();
            services.AddTransient<IPlatRepertoire, PlatRepertoire>();
            services.AddTransient<IReservationRepertoire, ReservationRepertoire>();
            services.AddTransient<IMenuRepertoire, MenuRepertoire>();

            return services;
        }
    }
}
