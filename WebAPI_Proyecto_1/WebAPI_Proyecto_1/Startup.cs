using AccesoDatos;
using AccesoDatos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Negocio.Interfaces.MongoDB;
using Negocio.Interfaces.SQLServer;
using Negocio.Metodos.MongoDB;
using Negocio.Metodos.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Proyecto_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Inyeccion de dependencias

            // Negocio
            services.AddTransient(typeof(ILogicaBitacora), typeof(LogicaBitacora));
            services.AddTransient(typeof(IClienteNSQL), typeof(ClienteNSQL));
            services.AddTransient(typeof(IHabitacionNSQL), typeof(HabitacionNSQL));
            services.AddTransient(typeof(IReservacionNSQL), typeof(ReservacionNSQL));
            services.AddTransient(typeof(IUsuarioNSQL), typeof(UsuarioNSQL));

            // Acceso Datos
            services.AddTransient(typeof(IAccesoMongoDB), typeof(AccesoMongoDB));
            services.AddTransient(typeof(IClientesADSQL), typeof(ClientesADSQL));
            services.AddTransient(typeof(IHabitacionesADSQL), typeof(HabitacionesADSQL));
            services.AddTransient(typeof(IReservacionesADSQL), typeof(ReservacionesADSQL));
            services.AddTransient(typeof(IUsuariosADSQL), typeof(UsuariosADSQL));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
