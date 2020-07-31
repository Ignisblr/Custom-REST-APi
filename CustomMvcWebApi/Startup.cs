using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMvcWebApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CustomMvcWebApi
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
            services.AddScoped<ICommanderRepo, MockCommandRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("swaggerDoc", new OpenApiInfo
                {
                    Title = "Swagger Document",
                    Version = "Custom Info",
                    Description = "Just some simple swagger document"
                });

                doc.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + @"CustomMvcWebApi.xml");
            });
            services.AddDbContext<CommanderContext>(options => options.UseSqlServer(Configuration.
                GetConnectionString("CommanderConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseSwagger().
            UseSwaggerUI(ui => { ui.SwaggerEndpoint("/swagger/swaggerDoc/swagger.json", "Swagger Document"); });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
