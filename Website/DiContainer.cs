using Website.Domain.Repositories.Abstract;
using Website.Domain.Repositories.EntityFramework;
using Website.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.Service;

namespace Website
{
	public class DiContainer  
	{
		public static void AddServices(WebApplicationBuilder builder)
		{
			//подключаем нужный функционал приложения в кач-ве сервисов

			builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
			builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
			builder.Services.AddTransient<DataManager>();

			//подключаю контекст бд
			builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));


			//настраиваю identity с-му 
			builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true; //подтверждение почты 
				opts.Password.RequiredLength = 6;
				opts.Password.RequireNonAlphanumeric = false; //использовать буквы и цифры
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false; //использовать только цифры
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			//настраиваю authentification cookie
			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "MyCompanyAuth";
				options.Cookie.HttpOnly = true; //недоступны на клиентской стороне
				options.LoginPath = "/account/login"; //для доступа панели администратора
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			//настраиваю политику конфиденциальности для Admin area
			builder.Services.AddAuthorization(x =>
			{
				x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
			});

			builder.Services.AddControllersWithViews(x =>
			{
				x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
			});
		}
	}
}
