﻿using Microsoft.Extensions.Logging.EventLog;

namespace Avto;

internal class Startup
{
    private static void Main()
    {
        Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            services.AddHostedService<StartAsService>();
            if (OperatingSystem.IsWindows())
            {
                services.Configure<EventLogSettings>(config =>
                {
                    if (OperatingSystem.IsWindows())
                    {
                        config.LogName = "Avto";
                        config.SourceName = "Avto Source";
                    }
                });
            }
        })
        .UseWindowsService()
        .Build()
        .Run();
    }
}

// sc create Avto binpath="d:\Avto\Avto.exe"
// sc start Avto