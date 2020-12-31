using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeManagement
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
         services.AddCors(options => {
            options.AddPolicy("mypolicy", builder => builder
             .WithOrigins("http://localhost:4200/")
             .SetIsOriginAllowed((host) => true)
             .AllowAnyMethod()
             .AllowAnyHeader());
         });

         services.Configure<EmployeeDatabaseSettings>(
             Configuration.GetSection(nameof(EmployeeDatabaseSettings)));

         services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
             sp.GetRequiredService<IOptions<EmployeeDatabaseSettings>>().Value);

         services.AddControllers();
         services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer(
            Configuration.GetConnectionString("EmployeeManagementConnection")   
         ));

         services.AddSingleton<IEmployeeTypeHandler, EmployeeTypeHandler>();
         services.AddSingleton<IEmployeeHandler, EmployeeHandler>();

         //services.AddScoped<IEmployeeRepository<SQLEmployee>, Repository.SQL.EmployeeRepository>();
         //services.AddScoped<IEmployeeTypeRepository<SQLEmployeeType>, Repository.SQL.EmployeeTypeRepository>();

         services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
         services.AddSingleton<IEmployeeTypeRepository, EmployeeTypeRepository>();

         services.AddAutoMapper(typeof(Startup));
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         app.UseRouting();
         app.UseCors("mypolicy");
         app.UseAuthorization();
        
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
