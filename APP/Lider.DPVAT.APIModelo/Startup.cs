using AutoMapper;
using Lider.DPVAT.APIModelo.Infra.CrossCutting.IOC;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using Lider.DPVAT.APIModelo.UI.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Extensions.Logging;
using NLog.Web;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Lider.DPVAT.APIModelo
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(environment.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile("versao.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                 .Build();

            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IOC iOC = new IOC();
            iOC.InjecaoAppService(services);
            iOC.InjecaoDomain(services);
            iOC.InjecaoRepository(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.ConfigureSwaggerGenOptions(Configuration);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(option =>
                  option.Configure(Configuration));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ExampleAPIProject", policy => policy.RequireClaim("ExampleAPIProject"));
            });

            services.AddMvcCore();
            services.AddResponseCompression();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddHealthChecks()
                   .AddGCInfoCheck("MEMORIA")
                   .AddCheck("BANCODEDADOS", new SqlConnectionHealthCheck(Configuration.GetConnectionString("ExampleAPIProjectContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddSessionStateTempDataProvider();
            services.AddAutoMapper();
            services.AddDbContext<ExampleAPIProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ExampleAPIProjectContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("NLog.config");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleAPIProject");
            });

            app.UseAuthentication();
            app.UseResponseCompression();
            app.UseHealthChecks("/check", new HealthCheckOptions()
            {
                ResponseWriter = WriteResponse,
            });

            app.UseMvc();
        }

        private static Task WriteResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";
            var json = new JObject(
            new JProperty("status", result.Status.ToString()),
            new JProperty("results", new JObject(result.Entries.Select(pair =>
            new JProperty(pair.Key, new JObject(
            new JProperty("status", pair.Value.Status.ToString()),
            new JProperty("description", pair.Value.Description),
            new JProperty("data", new JObject(pair.Value.Data.Select(p => new JProperty(p.Key, p.Value))))))))));
            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }
    }
}

