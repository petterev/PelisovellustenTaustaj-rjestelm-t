using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = "game-dev.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                //TextWriter tw = new StreamWriter(path);
                //tw.WriteLine("The very first line!");
                // tw.Close();
            }
            /* else if (File.Exists(path))
             {
                 TextWriter tw = new StreamWriter(path);
                 tw.WriteLine("The next line!");
                 tw.Close();
             }*/



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
