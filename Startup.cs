using MessageGenerator.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageGenerator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddHostedService<TimedHostedService>();

            services.AddCors(options =>
            {
                options.AddPolicy("Api", builder => builder
                     .WithOrigins("http://localhost:4200")
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials());
                });

            services.AddSignalR();
            services.AddControllers();
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

            app.UseCors("Api");

            app.UseRouting();

            app.UseEndpoints(builder =>
            {
                builder.MapControllers();

                builder.MapHub<MessageHub>("/hubs/messages");
            });


        }
    }
}
