using AutoMapper;
using GoogleBooksApplication.Interfaces;
using GoogleBooksApplication.Models;
using GoogleBooksApplication.Services;
using GoogleBooksData.Context;
using GoogleBooksDomain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace GoogleBooksApi
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
            services.AddControllers();

            services.AddScoped(typeof(HttpClient), typeof(HttpClient));

            services.AddScoped(typeof(IGoogleBooksService), typeof(GoogleBooksService));

            services.AddDbContext<SqliteContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("SqliteContext"), b => b.MigrationsAssembly("GoogleBooksData")));

            services.AddAutoMapper(typeof(BookModel), typeof(Book));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
