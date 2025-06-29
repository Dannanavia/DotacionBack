using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Application.Interfaces.Services;
using DotacionBack.Infrastructure.Persistence.Models;
using DotacionBack.Infrastructure.Persistence.Repositories;
using DotacionBack.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DotacionDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IDotacionRepository, EfDotacionRepository>();
            services.AddScoped<ISedeRepository, EfSedeRepository>();
            services.AddScoped<IInstitucionRepository, EfInstitucionRepository>();
            services.AddScoped<IMunicipioRepository, EfMunicipioRepository>();
            services.AddScoped<IUsuarioRepository, EfUsuarioRepository>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
