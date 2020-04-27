
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Collections.Generic;
using System.ComponentModel;


namespace RPS_Game
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            using(ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                GamePlay gamePlay = serviceProvider.GetService<GamePlay>();

                gamePlay.StartGame();
                gamePlay.RunGame();
                gamePlay.PrintResults();
            }
            
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging((configure) =>
            {
                configure.ClearProviders();
                configure.AddConsole();
                configure.SetMinimumLevel(LogLevel.Trace);
            })
            .AddTransient<GamePlay>();
        }
    }
}