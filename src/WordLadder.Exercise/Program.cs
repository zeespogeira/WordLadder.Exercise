using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Implementations.Runner;
using WordLadder.Exercise.Implementations.Services;
using WordLadder.Exercise.Implementations.WordLadderStrategies;

namespace WordLadder.Exercise
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            //create host
            using var host = CreateHostBuilder(args).Build();

            try
            {
                await host.Services.GetService<IRunner>().RunAsync();
            }
            catch (Exception e)
            {
                var logger = host.Services.GetService<ILogger<Runner>>();
                logger.LogError(e, "Unexpected exception");
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    //WordLadderStrategyV2 is the chosen implementation based on the benchmark results
                    //please check proj WordLadder.Exercise.BenchmarkTests
                    services.AddTransient<IWordLadderStrategy, WordLadderStrategyV2>() 

                            .AddTransient<IRunner, Runner>()
                            .AddTransient<ILoadWordsService, FileService>()
                            .AddTransient<IRunResultService, FileService>()
                            .AddTransient<IFileValidator, FileService>()
                            .AddTransient<IWordSetSanitizerService, WordSetSanitizerService>()
                            .AddTransient<IUIService, UIService>()
                            .AddTransient<ILogService, LogService>()
                            .AddLogging(builder =>
                            {
                                var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("logSettings.json", true, true)
                                    .Build();

                                var logger = new LoggerConfiguration()
                                    .ReadFrom.Configuration(configuration)
                                    .WriteTo.File($"log_{DateTime.UtcNow:yyyyMMdd}.log")
                                    
                                    .CreateLogger();

                                builder.AddSerilog(logger);
                            })
                            .AddFluentValidation(s =>
                            {
                                s.RegisterValidatorsFromAssemblyContaining<Program>();
                            })
                );
        }
    }
}
