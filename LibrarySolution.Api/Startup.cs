using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySolution.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LibrarySolution.Api.Data.Interfaces;
using LibrarySolution.Api.Repository;

namespace LibrarySolution.Api
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
            services.AddControllers();
            services.AddDbContext<DataContext>(mysql => 
            mysql.UseMySql(Configuration["MySqlConnection:ConnectionString"]));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

        //public static void ConfigureMysqlConnection(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var config = configuration.GetSection("ConnectionString");
        //    services.AddDbContext<DataContext>(mysql => mysql.UseMySql(config.Value));
        //}
    }
}
