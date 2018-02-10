using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.Core.Entity.CloudLink.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using IC.Core.Entity.CloudLink.Wx;
using IC.CloudLink.Services;
using IC.CloudLink.Services.Contracts;
using IC.CloudLink.Extensions;

namespace IC.CloudLink.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddDbService(services);
            AddWxService(services);
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStatusCodePages();
            app.UseExceptionHandler();
            app.UseMvc();
        }

        private void AddDbService(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:cloudLinkDB"];
            services.AddDbContext<CloudLinkDBContext>(o => o.UseMySQL(connectionString,b=>b.MigrationsAssembly("IC.CloudLink.WebApi")),ServiceLifetime.Singleton);

            services.AddTransient<IDBService, DBService>();
        }

        private void AddWxService(IServiceCollection services)
        {
            var appId = Configuration["wxAuthInfo:appId"];
            var appSercet = Configuration["wxAuthInfo:appSerect"];
            WxContext wxContext = new WxContext();
            wxContext.InitAuthInfo(appId, appSercet);

            services.AddSingleton(wxContext);

            services.AddTransient<IWxService, WxService>();
        }
    }
}
