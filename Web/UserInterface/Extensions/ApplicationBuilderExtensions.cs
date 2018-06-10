using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Solution.Web.UserInterface.Middlewares;

namespace Solution.Web.UserInterface.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseCorsCustom(this IApplicationBuilder application)
		{
			application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
		}

		public static void UseExceptionCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			if (environment.IsDevelopment())
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

		public static void UseHstsCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			if (!environment.IsDevelopment())
			{
				application.UseHsts();
			}
		}

		public static void UseSpaCustom(this IApplicationBuilder application, IHostingEnvironment environment)
		{
			application.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (environment.IsDevelopment())
				{
					spa.UseAngularCliServer("serve");
				}
			});
		}
	}
}
