using System.Net.Mime;
using LimeHome.BackEnd.Demo.DataAccess;
using LimeHome.BackEnd.Demo.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LimeHome.BackEnd.Demo
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

            services.ConfigureWithDataAnnotationsValidation<ApplicationOptions>(Configuration.GetSection(nameof(MediaTypeNames.Application)));

            services.AddSingleton<IHereApi,HereApi>();
            services.AddLazyScoped<BookingStore>();

            services.AddMvc(o =>
            {
                o.ValueProviderFactories.Insert(0, new SeparatedQueryStringValueProviderFactory(","));
                o.Conventions.Add(new CommaSeparatedQueryStringConvention());
            });
            services.AddEntityFrameworkNpgsql().AddDbContext<BookingDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("BookingDb")));

            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
