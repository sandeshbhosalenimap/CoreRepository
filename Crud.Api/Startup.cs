
using AutoMapper;
using Crude.Api.Controllers;
using Crude.Api.Middleware;
using Crude.Api.Service.IService;
using Crude.Api.Service.Service;
using Crude.Models.DTO;
using DataBase;
using DataBase.IRepository;
using DataBase.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Crude.Api
{
    public class Startup
    {
        public  string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
     
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DataBaseContext");
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(ConnectionString));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentServices,  StudentServices>();
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);  


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CORE_5_API", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CORE_5_API v1"));
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();
    
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
