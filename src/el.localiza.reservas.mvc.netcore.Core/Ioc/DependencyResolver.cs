using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.Core.Service;
using el.localiza.reservas.mvc.netcore.DataSource.Requests;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Core.Ioc
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterServices(services);
            RegisterRefit(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
        }

        private static void RegisterRefit(IServiceCollection services)
        {
            //Refit Api Reservas
            services.AddRefitClient<IRefitReservasApi>()
                   .ConfigureHttpClient(c =>
                   {
                       c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("EL_RESERVAS_REFIT_API_BASE"));
                       c.DefaultRequestHeaders.Add("Accept", "application/json");
                   });
        }      
    }
}
