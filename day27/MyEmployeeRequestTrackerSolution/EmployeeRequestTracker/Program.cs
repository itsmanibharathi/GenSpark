using EmployeeRequestTracker.Context;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Profiles;
using EmployeeRequestTracker.Repositories;
using EmployeeRequestTracker.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllers();


            builder.Services.AddAutoMapper(typeof(MappingProfile));
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context
            builder.Services.AddDbContext<DBEmpReqTrackerContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}