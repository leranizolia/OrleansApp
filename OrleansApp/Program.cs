using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Clustering.AdoNet;
using Orleans;
using Orleans.Hosting;
using Orleans.Configuration;
using System.Net;

using MySql.Data.MySqlClient;
using System.Data.Common;
using OrleansApp.CallFilters;

namespace OrleansApp
{

    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
        .UseOrleans(builder =>
        {
            //builder.UseLocalhostClustering();

            builder.UseAdoNetClustering(options =>
            {
                options.Invariant = "MySql.Data.MySqlClient";
                options.ConnectionString = "Server=localhost;user=root; Database=Orleans";
            });

            builder.UseAdoNetReminderService(options =>
            {
                options.Invariant = "MySql.Data.MySqlClient";
                options.ConnectionString = "Server=localhost;user=root; Database=Orleans";
            });
            builder.AddAdoNetGrainStorage("OrleansStorage", options =>
            {
                options.Invariant = "MySql.Data.MySqlClient";
                options.ConnectionString = "Server=localhost;user=root; Database=Orleans";
                options.UseJsonFormat = true;
            });
            builder.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IHelloWorldGrain).Assembly));

            builder.Configure<EndpointOptions>(options =>
            {
                options.AdvertisedIPAddress = IPAddress.Loopback;
                options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, EndpointOptions.DEFAULT_GATEWAY_PORT);
                options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, EndpointOptions.DEFAULT_SILO_PORT);

            });
            builder.Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "Cluster";
                options.ServiceId = "Service";
            });
            //builder.AddIncomingGrainCallFilter<ConsoleWritingIncomingCallFilter>();
            //builder.AddOutgoingGrainCallFilter<ConsoleWritingOutgoingCallFilter>();

        });
    }
}


