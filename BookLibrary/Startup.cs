using AutoMapper;
using AutoMapper.EquivalencyExpression;

using BookLibrary.Core.Services;
using BookLibrary.Data;
using BookLibrary.Data.Services;
using BookLibrary.Db;
using BookLibrary.Db.Interfaces;
using BookLibrary.Db.Models;
using BookLibrary.Db.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAntDesign();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<ApplicationContext>(serviceProvider);
            }, typeof(AutoMapperProfile).Assembly);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBinaryFileRepository, BinaryFileRepository>();
            services.AddScoped<IBookGroupRepository, BookGroupRepository>();

            services.AddScoped<IFileService, LocalFileService>();
            services.AddScoped<ITemporaryFileService, TemporaryFileService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.UseHttpsRedirection();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}