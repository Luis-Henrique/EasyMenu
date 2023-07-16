using EasyMenu.Api.Admin.Controllers.v1;
using EasyMenu.Application.Data.MySql.Repositories;
using EasyMenu.Application.Data.SqlServer;
using EasyMenu.Application.Data.SqlServer.Repositories;
using EasyMenu.Application.Helpers;
using EasyMenu.Application.Interfaces;
using EasyMenu.Application.Services;
using EasyRestaurant.Application.Data.SqlServer.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EasyMenu.API.Admin
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        readonly string CorsPolicy = "_corsPolicy";
        public void BeforeConfigureServices(IServiceCollection services)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            services.AddAuthentication("BasicAuthentication")
                      .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            BeforeConfigureServices(services);

            services.AddApiVersioning();

            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));       
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EasyMenu.API", Version = "v1" });
            });

            services.AddScoped<UserService>();
            services.AddScoped<UserRepository>();

            services.AddScoped<DishesService>();
            services.AddScoped<DishesRepository>();

            services.AddScoped<MenuService>();
            services.AddScoped<MenuRepository>();

            services.AddScoped<MenuOptionService>();
            services.AddScoped<MenuOptionRepository>();

            services.AddScoped<RestaurantService>();
            services.AddScoped<RestaurantRepository>();

            services.AddScoped<DisheTypeService>();
            services.AddScoped<DisheTypeRepository>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo("en-US") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyMenu.API v1"));

            app.UseCors(CorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();
        }
    }
}
