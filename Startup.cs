
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BenderApi.Business.Database;
using BenderApi.Business.Deploy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenderApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public CorsPolicy GenerateCorsPolicy(){
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.WithOrigins("http://localhost:8080"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();
            return corsBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins", GenerateCorsPolicy());
                });

            var builder = new ContainerBuilder();
            builder.Populate(services);  
            builder.RegisterType<DeployHandler>().As<IDeployHandler>();   
            builder.RegisterType<DatabaseRepository>().As<IDatabaseRepository>();   

            var ApplicationContainer = builder.Build();
            
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAllOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
