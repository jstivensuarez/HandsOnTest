using AutoMapper;
using HandsOnTest.Business;
using HandsOnTest.Business.Factories;
using HandsOnTest.Business.Factories.Impl;
using HandsOnTest.Business.Services;
using HandsOnTest.Business.Services.Impl;
using HandsOnTest.Data;
using HandsOnTest.Data.Repositories;
using HandsOnTest.Data.Repositories.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
namespace HandsOnTest.Api
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
            //Data 
            services.AddScoped<IHttpRequestTemplate, HttpRequestTemplate>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Business
            services.AddScoped<IEmployeeFactory, EmployeeFactory>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            //Configuration
            services.AddScoped<IRestClient>(r => new RestClient());
            var configurationSection = Configuration.GetSection("Configuration");

            services.Configure<Configuration.Configuration>(configurationSection);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            services.AddScoped(m => mappingConfig.CreateMapper());

            services.AddSwaggerGen();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseCors("AllowAll");

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
