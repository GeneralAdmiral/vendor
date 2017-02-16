using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using vendor.domain.entities;
using vendor.domain.data.concretes;
using vendor.ui.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace vendor.ui
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<VendorDbContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<VendorDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<VendorDbContext, long>()
                .AddUserStore<UserStore>()
                .AddDefaultTokenProviders();

            Resolver.Init(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
