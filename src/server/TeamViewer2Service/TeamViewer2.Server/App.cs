using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer2.Chat;

namespace TeamViewer2.Server
{
    public class App
    {
        public App(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(300);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(300);
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(100);

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
                o.MaximumReceiveMessageSize = 2000 * 1024 * 1024;
                GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = null;

            });

            services.AddLogging(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("NToastNotify", LogLevel.Warning)
                        .AddConsole();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRouting();
            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
