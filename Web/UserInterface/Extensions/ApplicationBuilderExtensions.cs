using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Solution.CrossCutting.DependencyInjection;
using Solution.Web.UserInterface.Middlewares;

namespace Solution.Web.UserInterface.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		private static readonly IHostingEnvironment _environment = DependencyInjector.GetService<IHostingEnvironment>();

		public static void UseCorsCustom(this IApplicationBuilder application)
		{
			application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
		}

		public static void UseExceptionCustom(this IApplicationBuilder application)
		{
			if (_environment.IsDevelopment())
			{
				application.UseDeveloperExceptionPage();
				application.UseDatabaseErrorPage();
			}

			application.UseExceptionMiddleware();
		}

		public static void UseExceptionMiddleware(this IApplicationBuilder application)
		{
			application.UseMiddleware<ExceptionMiddleware>();
		}

		public static void UseHstsCustom(this IApplicationBuilder application)
		{
			if (!_environment.IsDevelopment())
			{
				application.UseHsts();
			}
		}

		public static void UseSpaCustom(this IApplicationBuilder application)
		{
			application.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (_environment.IsDevelopment())
				{
					spa.UseAngularCliServer("serve");
				}
			});
		}
	}
}
