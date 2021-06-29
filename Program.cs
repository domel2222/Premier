using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Premier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// enable internal logging to the console
            //NLog.Common.InternalLogger.LogToConsole = true;

            //// enable internal logging to a file
            //NLog.Common.InternalLogger.LogFile = "c:\\nlog-internal.txt"; // On Linux one can use "/home/nlog-internal.txt"

            //// enable internal logging to a custom TextWriter
            //NLog.Common.InternalLogger.LogWriter = new StringWriter(); //e.g. TextWriter writer = File.CreateText("C:\\perl.txt")

            //// set internal log level
            //NLog.Common.InternalLogger.LogLevel =

            //// Perform test output, ensure first NLog Logger is created after InternalLogger is enabled.
            //NLog.LogManager.GetLogger("Test").Info("Hello World");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
            .UseNLog();
    }
}
