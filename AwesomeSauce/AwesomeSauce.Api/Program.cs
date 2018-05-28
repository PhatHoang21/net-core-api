using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AwesomeSauce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        ////Default
        //public static IWebHost BuildWebHost(string[] args) =>
        //    new WebHostBuilder()
        //    .UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .ConfigureAppConfiguration(config =>
        //        config.AddJsonFile("appSettings.json", true)
        //    )
        //    .ConfigureLogging(logging =>
        //        logging
        //            .AddConsole()
        //            .AddDebug()
        //    )
        //    .UseIISIntegration()
        //    .UseStartup<Startup>()
        //    .Build();
    }
}
