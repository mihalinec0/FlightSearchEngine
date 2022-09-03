using DAL;
using FlightSearchEngine.Constants;
using FlightSearchEngine.Implementations;
using FlightSearchEngine.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Fluent;
using NLog.Web;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
        logger.Debug("init main");

        try
        {

            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient(HttpClientConstants.HttpAuthorizationClient, httpClient =>
                {
                    httpClient.BaseAddress = new Uri(HttpClientConstants.AuthorizationLink);

                });

            builder.Services.AddHttpClient(HttpClientConstants.HttpAuthorizationClient, httpClient =>
            {
                httpClient.BaseAddress = new Uri(HttpClientConstants.GetFlightsDataLink);

            });

            builder.Services.AddScoped<IHttpServices, HttpServices>();

            var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));

            builder.Services.AddDbContext<FlightSearchEngineDbContext>(options =>
            {
                options.UseSqlServer(connectionStringBuilder.ConnectionString);
                options.EnableSensitiveDataLogging(true);
            });

            builder.Logging.ClearProviders();

            builder.Host.UseNLog();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            NLog.LogManager.Shutdown();
        }
    }
}