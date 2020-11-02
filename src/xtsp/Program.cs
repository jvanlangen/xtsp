//  
// Copyright (c) vanLangen.biz. All rights reserved.  
// Licensed under the MIT license. See LICENSE file in the project root for full license information.  
//  
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
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Startup");

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IXTSPCore, XTSPCore>()
                .AddSingleton<ILoggerFactory>(sp => loggerFactory)
                .BuildServiceProvider();

            // Get an instance of the core
            var core = serviceProvider.GetService<IXTSPCore>();

            // Run
            await core.Run();

            logger.LogInformation("Stopped"); 
        }
    }
}
