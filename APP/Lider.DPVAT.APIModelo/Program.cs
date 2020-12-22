using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.LayoutRenderers;
using NLog.Web;
using Lider.DPVAT.APIModelo.UI.Extension;

namespace Lider.DPVAT.APIModelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LayoutRenderer.Register("user-domain", (logEvent) => Environment.UserDomainName);
            LayoutRenderer.Register("user-name", (logEvent) => Environment.UserName);
            LayoutRenderer.Register("os-version", (logEvent) => Environment.OSVersion);
            LayoutRenderer.Register("current-directory", (logEvent) => Environment.CurrentDirectory);
            LayoutRenderer.Register("custom-shortdate", (logEvent) => DateTime.Now.ToString("yyyyMMdd"));
            LayoutRenderer.Register("application-name", (logEvent) => Assembly.GetExecutingAssembly().FullName);

            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("Iniciando o Log do NLOG");

                var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("hosting.json", optional: true)
                           .Build();
                
                var host = WebHost.CreateDefaultBuilder(args) //new WebHostBuilder()
                    .UseStartup<Startup>()
                    .UseConfiguration(config)
                    .UseKestrel(options => options.ConfigureEndpoints())
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseNLog()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Programa parado por causa de uma exception.");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
