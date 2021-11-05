using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebServiceRBP.Data;
using WebServiceRBP.Data.Configuration;

namespace WebServiceRBP
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
            services.AddControllers();
            //mongodb
            services.Configure<dbDatabaseSettings>(
                            Configuration.GetSection(nameof(dbDatabaseSettings)));

            services.AddSingleton<IdbDatabaseSettings>(sp =>
                            sp.GetRequiredService<IOptions<dbDatabaseSettings>>().Value);

            services.AddSingleton<dbValoresEntradaDb>();

            //mongodb
            services.Configure<RaspberryPiDatabaseSettings>(
                            Configuration.GetSection(nameof(RaspberryPiDatabaseSettings)));

            services.AddSingleton<IRaspberryPiDatabaseSettings>(sp =>
                            sp.GetRequiredService<IOptions<RaspberryPiDatabaseSettings>>().Value);

            services.AddSingleton<ValoresEntradaDb>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
