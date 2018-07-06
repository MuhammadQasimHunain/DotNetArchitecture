using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.CrossCutting.AspNetCore.Extensions;

namespace Solution.Api.Authentication
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void Configure(IApplicationBuilder application)
		{
			application.UseExceptionCustom();
			application.UseAuthentication();
			application.UseCorsCustom();
			application.UseHstsCustom();
			application.UseHttpsRedirection();
			application.UseMvcWithDefaultRoute();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDependencyInjectionCustom(Configuration);
			services.AddAuthenticationCustom();
			services.AddCors();
			services.AddMvcCustom();
		}
	}
}
