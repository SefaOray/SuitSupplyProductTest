using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuitSupplyProductTest.Data;
using SuitSupplyProductTest.Data.Config;
using SuitSupplyProductTest.Models;
using SuitSupplyProductTest.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace SuitSupplyProductTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigureMaps();
        }

        private void ConfigureMaps()
        {
            Mapper.Initialize(cfg =>
                cfg.CreateMap<ProductModel, Product>()
                    .ForMember(dest => dest.Id, opt => opt.UseValue(default(int)))
                    .ForMember(dest => dest.LastUpdated, opt => opt.UseValue(default(DateTime)))
            );

        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SuitSupply Product Api", Version = "v1" });
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                c.IncludeXmlComments(commentsFile);
            });

            services.AddApiVersioning(cfg => {
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                });
            var builder = new ContainerBuilder();

            builder.Populate(services);

            var dataCnf = new DataConfig();
            Configuration.GetSection("DataConfig").Bind(dataCnf);

            builder.RegisterInstance<DataConfig>(dataCnf);
            builder.RegisterType<EfDbContext>().As<EfDbContext>();
            builder.RegisterType<ProductDataAccess>().As<IProductDataAccess>();

            builder.RegisterType<ProductService>().As<IProductService>();

            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());



            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
