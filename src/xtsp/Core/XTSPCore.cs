//  
// Copyright (c) vanLangen.biz. All rights reserved.  
// Licensed under the MIT license. See LICENSE file in the project root for full license information.  
//  
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xtsp.Core
{
    public class XTSPCore : IXTSPCore
    {
        private readonly ILogger<IXTSPCore> _logger;

        public XTSPCore(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<IXTSPCore>();
        }

        public async Task Run()
        {
            _logger.LogInformation("Run is called");

            await Task.Delay(1000);
            _logger.LogInformation("bla");
        }
    }
}
