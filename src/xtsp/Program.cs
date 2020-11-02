using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;
using xtsp.Core;

namespace xtsp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                var serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddSingleton<IXTSPCore, XTSPCore>()
                    .AddSingleton<ILoggerFactory>(sp => loggerFactory)
                    .BuildServiceProvider();

                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogInformation("Starting application");

                //do the actual work here
                var core = serviceProvider.GetService<IXTSPCore>();
                await core.Run();

                logger.LogInformation("All done!");
            }
        }
    }
}
