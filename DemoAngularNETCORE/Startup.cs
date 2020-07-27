using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DemoAngularNETCORE.Models;
using Microsoft.EntityFrameworkCore;
using DemoAngularNETCORE.Models.Repository;
using DemoAngularNETCORE.Models.DataManager;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace DemoAngularNETCORE
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

            services.AddDbContext<EmployeeContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:EmployeeDB2"]));
            services.AddScoped<IDataRepository<Employee>, DataManager>();
            services.AddControllers();
            //services.AddCors();

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

            app.UseCors(options =>
           options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
            .AllowAnyHeader());

            //app.UseMvc();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}