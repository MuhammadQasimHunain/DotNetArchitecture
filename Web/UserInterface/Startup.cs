using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Web.UserInterface.Extensions;

namespace Solution.Web.UserInterface
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder application)
		{
			application.UseExceptionCustom();
			application.UseAuthentication();
			application.UseCorsCustom();
			application.UseHstsCustom();
			application.UseHttpsRedirection();
			application.UseStaticFiles();
			application.UseSpaStaticFiles();
			application.UseResponseCaching();
			application.UseMvcWithDefaultRoute();
			application.UseSpaCustom();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDependencyInjectionCustom(Configuration);
			services.AddAuthenticationCustom();
			services.AddCors();
			services.AddResponseCaching();
			services.AddMemoryCache();
			services.AddMvcCustom();
			services.AddSpaStaticFilesCustom();
		}
	}
}
