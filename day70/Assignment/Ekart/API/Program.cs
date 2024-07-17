using API.Context;
using API.Models;
using API.Repositorys;
using API.Services;
using log4net.Config;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Log4NetConfig
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
            #endregion

            #region Builder Configuration
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging(l => l.AddLog4Net());

            #region DBContext
            builder.Services.AddDbContext<DBEkartContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBEkartContext"));
            });
            #endregion

            #region Repositorys
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            #region App Configuration
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
