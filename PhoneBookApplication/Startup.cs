using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApplication.Components;
using PhoneBookApplication.Components.Interfaces;
using PhoneBookApplication.Helpers;
using PhoneBookApplication.Repository.Sql;
using PhoneBookApplication.Repository.Sql.Interfaces;

namespace PhoneBookApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile(ValuesHelper.APP_SETTINGS_JSON, optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetSection(ValuesHelper.SQL_CONNECTION).Value;
            SqlConfiguration configuration = new SqlConfiguration(connectionString);
            services.AddSingleton<ISqlConfiguration>(configuration);
            services.AddSingleton<ISqlRepository, SqlRepository>();
            services.AddSingleton<IPhoneBookComponent, PhoneBookComponent>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(ValuesHelper.ERROR_PATH);
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: ValuesHelper.DEFAULT,
                    pattern: ValuesHelper.CONTROLLER_PATTERN);
            });
        }
    }
}
