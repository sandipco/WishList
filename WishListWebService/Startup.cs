using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using WishListWebService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using WishListWebService.Data;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using WishListWebService.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WishListWebService
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        //public void ConfigureServices(IServiceCollection services,IHostingEnvironment env)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddIdentity<WishListUser, IdentityRole>(
                config=>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 8;
                    config.Password.RequireNonLetterOrDigit = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<WishListContext>();

            //services.AddScoped<ImailService, MailService>();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WishListContext>();
            services.AddTransient<WishListSeed>();
            services.AddScoped<IWishListRepository, WishListRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, WishListSeed seedData)
        {
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseIISPlatformHandler();
            Mapper.Initialize(config =>
            {
                config.CreateMap<VmWishList, WishList>().ReverseMap();
            });
            app.UseMvc(config=>
            {
                config.MapRoute(
                        name: "Default",
                        template: "{controller}/{action}/{id?}",
                        defaults: new { controller = "App", action = "Index" }
                    );
            });
            await seedData.EnsureSeedDone();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
