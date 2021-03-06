using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KampusStudio.Models.Services.Application;
using KampusStudio.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace kampus
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        /*
        QUESTA CLASSE VIENE SOSTITUITA PERCHE' NON FUNZIONA CON LA VERSIONE 3.0 DI DOTNET
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        */

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IComuneService, AdoNetComuneService>();  // Per far accettare le interfacce
            services.AddTransient<IRegioneService, AdoNetRegioneService>();  // Per far accettare le interfacce
            services.AddTransient<IProvinciaService, AdoNetProvinciaService>();  // Per far accettare le interfacce            
            services.AddTransient<IDatabaseAccessor, MySqlDatabaseAccessor>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            /* QUESTO METODO E' COMPATIBILE CON LA VERSIONE 3.0 DI DOTNET, DIVERSA DA QUELLA INDICATA NEL VIDEO */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
