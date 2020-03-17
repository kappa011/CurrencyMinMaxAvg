using AutoMapper;
using CurrencyMinMaxAvg.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.IO;

namespace CurrencyMinMaxAvg.API
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
            services.AddScoped<ICallExternalApiService, CallExternalApiService>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            //.SetCompatibilityVersion(CompatibilityVersion.Version_3_1);

            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1",
                      new OpenApiInfo { Title = "Currency Exchange Rates API - Min, Max, Average", Version = "v1" });
                  c.DescribeAllEnumsAsStrings();
              });

            services.AddAutoMapper(typeof(Startup));

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Swagger")),
                RequestPath = "/swagger"
            });

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Currency Exchange Rates API - Min, Max, Average v1");
                c.SwaggerEndpoint("/swagger/swagger.json", "Currency Exchange Rates API - Min, Max, Average v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
