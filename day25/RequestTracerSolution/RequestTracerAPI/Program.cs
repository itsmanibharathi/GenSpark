using Microsoft.EntityFrameworkCore;
using RequestTracerAPI.Context;
using RequestTracerAPI.Interfaces;
using RequestTracerAPI.Models;
using RequestTracerAPI.Repositories;
using RequestTracerAPI.Services;

namespace RequestTracerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Context
            builder.Services.AddDbContext<DBRequestTrackerContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int,Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int,User>, UserRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IUserService, EmployeeService>();
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
