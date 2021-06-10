using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection AddBLL (this IServiceCollection services)
        {
            return services;
        }
    }
}
