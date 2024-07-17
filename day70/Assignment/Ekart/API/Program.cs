using API.Context;
using API.Models;
using API.Repositorys;
using API.Services;
using log4net.Config;
using log4net;
using Microsoft.EntityFrameworkCore;
using API.Utility;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            DotNetEnv.Env.Load();
            #region Log4NetConfig
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
            #endregion

            #region Builder Configuration
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging(l => l.AddLog4Net());
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            #region DBContext
            var keyVaultName = "kvmani1";
            var client = new SecretClient(new Uri($"https://{keyVaultName}.vault.azure.net"), new DefaultAzureCredential());
            var connectionString = (await client.GetSecretAsync("DBConnectionString")).Value.Value;
            builder.Services.AddDbContext<DBEkartContext>(options => options.UseSqlServer(connectionString));
            #endregion
            
            #region Repositorys
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            #region AzureBlobStorageService

            var azureBlobStorageConnectionString = (await client.GetSecretAsync("AzureBlobStorageConnectionString")).Value.Value;
            builder.Services.AddTransient<AzureBlobStorageService>(provider => new AzureBlobStorageService(azureBlobStorageConnectionString));


            #endregion

            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(option =>
                {
                    option.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
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
            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
