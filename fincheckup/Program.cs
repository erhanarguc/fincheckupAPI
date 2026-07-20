using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace fincheckup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

         //.UseIISIntegration().UseStartup<Startup>();

         .UseKestrel(options =>
          {
              options.AddServerHeader = false;
              options.Limits.MaxRequestBodySize = long.MaxValue;

          }
        //)
        //.UseSerilog((hostingContext, loggerConfig) =>
        //       loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
        )
         .UseStartup<Startup>();


    }
}
