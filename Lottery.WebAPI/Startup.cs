using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.WebAPI.Data;
using Lottery.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lottery.WebAPI
{
    public class Startup
    {
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LotteryDbContext>((serverProvider, options) =>
                    options.UseSqlServer(connectionString).UseInternalServiceProvider(serverProvider));

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<LotteryDbContext>()
                .UseSqlServer(connectionString);

            services.AddSingleton(dbContextOptionsBuilder.Options);

            services.AddSingleton<ITicketService, TicketService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Lottery/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Lottery}/{action=Index}/{id?}");
            });
        }
    }
}
