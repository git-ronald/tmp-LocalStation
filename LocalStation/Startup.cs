﻿using Microsoft.Extensions.DependencyInjection;
using PeerLibrary.Configuration;
using TestAppLibrary.Configuration;

namespace LocalStation
{
    internal static class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddPeerLibrary()
                .AddTestApp()
                .BuildServiceProvider();
        }
    }
}
