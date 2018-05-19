using Consensus.CompositionRoot;
using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Extensions;
using ConsensusTester.Services.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;

namespace ConsensusTester
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrap.RegisterServices(services);

            services.AddDbContext<ConsensusContext>(o =>
            {
                string connStr = Configuration.GetConnectionString(_hostingEnvironment.EnvironmentName);
                if (String.IsNullOrWhiteSpace(connStr))
                {
                    throw new Exception($"No connection string defined for {_hostingEnvironment.EnvironmentName}");
                }
                o.UseSqlServer(connStr);
            }, ServiceLifetime.Scoped);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    AllowIntegerValues = false,
                    CamelCaseText = false
                });
                options.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset;
                options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            });

            services.AddCors(o => o.AddPolicy("CORS", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.ConfigureFromSection<ConsensusOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("CORS");
        }
    }
}