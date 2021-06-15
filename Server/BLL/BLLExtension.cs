using DAL;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection AddBLL (this IServiceCollection services)
        {
            // Liaison à la DAL via Injecteur de dépendance
            services.AddDAL();

            // Les services de la BLL
            services.AddTransient<ICommandeService, CommandeService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IManagementService, ManagementService>();
            services.AddTransient<IRestaurationService, RestaurationService>();

            return services;
        }
    }
}
