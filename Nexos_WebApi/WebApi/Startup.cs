using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Datos.Contexto;
using WebApi.Datos.Interface;
using WebApi.Datos.Servicio;
using WebApi.Negocio.Interface;
using WebApi.Negocio.Servicio;

namespace WebApi
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
            var sqlConnectionString = Configuration.GetConnectionString("CadenaConexion");
            services.AddDbContext<HospitalContexto>(options => options.UseSqlServer(sqlConnectionString, option => option.MigrationsAssembly("WebApi.Migracion_SQL_Server")));
            services.AddControllers();
            services.AddTransient<IServiciosDatosDoctor, ServicioDatosDoctor>();
            services.AddTransient<IServiciosDatosPacientes, ServiciosDatosPacientes>();
            services.AddTransient<IServiciosDoctores, ServicioNegocioDoctor>();
            services.AddTransient<IServiciosPacientes, ServicioNegocioPacientes>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    // .AllowCredentials()
            );
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
