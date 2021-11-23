using System.Reflection;
using _03_Way.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace _03_Way;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        await host.InvokeCommandsAsync(args);
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddCommandLine(args);
                config.AddEnvironmentVariables();
                config.SetBasePath(GetDirectoryPath());
                var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
            })
            .ConfigureLogging((hostingContext, loggingBuilder) =>
            {
                loggingBuilder.AddConsoleLogger();
                loggingBuilder.AddNonGenericLogger();
                loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            })
            .ConfigureServices(services =>
            {
                services.AddCommands();
            });

    private static void AddConsoleLogger(this ILoggingBuilder loggingBuilder)
    {
        if (!File.Exists(GetSettingFilePath()))
        {
            loggingBuilder.AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.IncludeScopes = true;
                options.UseUtcTimestamp = true;
                options.TimestampFormat = "[HH:mm:ss:fff] ";
                options.ColorBehavior = LoggerColorBehavior.Enabled;
            });
        }
    }

    private static void AddNonGenericLogger(this ILoggingBuilder loggingBuilder)
    {
        var categoryName = typeof(Program).Namespace ?? string.Empty;
        var services = loggingBuilder.Services;
        services.AddSingleton(serviceProvider =>
        {
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            return loggerFactory.CreateLogger(categoryName);
        });
    }

    private static string GetSettingFilePath() => Path.GetFullPath(Path.Combine(GetDirectoryPath(), @"appsettings.json"));

    private static string GetDirectoryPath()
    {
        try
        {
            return Path.GetDirectoryName(GetAssemblyLocation()) ?? "./";
        }
        catch
        {
            return Directory.GetCurrentDirectory();
        }
    }

    private static string GetAssemblyLocation() => Assembly.GetExecutingAssembly().Location;
}