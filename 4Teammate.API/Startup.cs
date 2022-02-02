using _4Teammate.API.Database;
using _4Teammate.API.Database.Repositories.Interfaces;
using _4Teammate.API.Database.Repositories.Realization;
using _4Teammate.API.Services.Interfaces;
using _4Teammate.API.Services.Realization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _4Teammate.API
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

            services.AddCors(opt =>
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
                })
            );
            
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicationDataContext>(options => options.UseSqlServer(connection));

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ILookupCategoryRepository, LookupCategoryRepository>();
            services.AddScoped<ISportCategoryRepository, SportCategoryRepository>();
            services.AddScoped<ISportLookupRepository, SportLookupRepository>();
            services.AddScoped<ISportTypeRepository, SportTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILookupCategoryService, LookupCategoryService>();
            services.AddScoped<ISportCategoryService, SportCategoryService>();            
            services.AddScoped<ISportLookupService, SportLookupService>();
            services.AddScoped<ISportTypeService, SportTypeService>();
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
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
