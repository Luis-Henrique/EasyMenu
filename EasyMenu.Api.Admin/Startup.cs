using EasyMenu.Application.Data.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
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

            services.AddScoped<SqlServerContext>();
            services.Configure<AppConnectionSettings>(option => Configuration.GetSection("ConnectionStrings").Bind(option));

            services.AddSwaggerGen();
   

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
            app.UseSwaggerUI();

            app.UseCors(CorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();
        }
    }
}
