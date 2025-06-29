using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotacionBack.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;



namespace DotacionBack.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<DotacionDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<InstitucionDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<DotacionDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<SedeDtoValidator>();

            return services;
        }
    }
}
