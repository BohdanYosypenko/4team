using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Data.Repositories.Realization;
using _4Teammate.Data.Services.Realization;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace _4Teammate.API;

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

        RegisterCorsPolicy(services);

        RegisterDb(services, Configuration);

        RegisterAuthentication(services, Configuration);

        services.AddAutoMapper(typeof(Startup));

        RegisterServicesImplementation(services);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API",
                Version = "v1",
                Description = "4Teammate API Information"
            });
        });
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

        app.UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API"));

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }

    private static void RegisterServicesImplementation(IServiceCollection services)
	{
        services.AddScoped<ILookupCategoryRepository, LookupCategoryRepository>();
        services.AddScoped<ISportCategoryRepository, SportCategoryRepository>();
        services.AddScoped<ISportLookupRepository, SportLookupRepository>();
        services.AddScoped<ISportTypeRepository, SportTypeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ILookupCategoryService, LookupCategoryService>();
        services.AddScoped<ISportCategoryService, SportCategoryService>();
        services.AddScoped<ISportLookupService, SportLookupService>();
        services.AddScoped<ISportTypeService, SportTypeService>();

        services.AddScoped<TokenService>();
    }

    private static void RegisterDb(IServiceCollection services, IConfiguration configuration)
	{
        string connection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AplicationDataContext>(options => options.UseSqlServer(connection));

        services.AddIdentityCore<User>(opt => { opt.Password.RequireNonAlphanumeric = false; })
            .AddEntityFrameworkStores<AplicationDataContext>()
            .AddSignInManager<SignInManager<User>>();
    }

    private static void RegisterCorsPolicy(IServiceCollection services)
	{
        services.AddCors(opt =>
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));
    }

    private static void RegisterAuthentication(IServiceCollection services, IConfiguration configuration)
	{
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        services.AddControllers(opt =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });
    }
}
