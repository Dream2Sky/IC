using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IC.Core.Entity.CloudLink.Wx;
using IC.Wx.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IC.Wx.Gateway
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
            AddWxService(services);
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
        }

        private void AddWxService(IServiceCollection services)
        {
            var appId = Configuration["WxAuthInfo:AppId"];
            var appSercet = Configuration["WxAuthInfo:AppSerect"];
            WxContext wxContext = new WxContext();
            wxContext.AuthInfo.AppId = appId;
            wxContext.AuthInfo.AppSercet = appSercet;

            services.AddSingleton(wxContext);

            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
