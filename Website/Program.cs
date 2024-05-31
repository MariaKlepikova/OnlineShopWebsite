using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.Domain;
using Website.Domain.Repositories.Abstract;
using Website.Domain.Repositories.EntityFramework;
using Website.Service;

namespace Website
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // подключаю конфиг из appsettings.json
            var projectConfigSection = builder.Configuration.GetSection("Project");

            Config.ConnectionString = projectConfigSection[nameof(Config.ConnectionString)].ToString();

            Config.CompanyEmail = projectConfigSection[nameof(Config.CompanyEmail)].ToString();

			Config.CompanyPhone = projectConfigSection[nameof(Config.CompanyPhone)].ToString();

			Config.CompanyPhoneShort = projectConfigSection[nameof(Config.CompanyPhoneShort)].ToString();

			Config.CompanyName = projectConfigSection[nameof(Config.CompanyName)].ToString();

            DiContainer.AddServices(builder);

			var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

			// подключаю поддержку статичных файлов в приложении (css,js и тд)
			app.UseStaticFiles();

            //подключаю с-му маршрутизации
            app.UseRouting();

            // подключаю аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});

			app.Run();
        }
    } 
}
