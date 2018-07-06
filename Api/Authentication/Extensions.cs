using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Database;

namespace Solution.Api.Authentication
{
	public static class Extensions
	{
		public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
		{
			DependencyInjector.RegisterServices(services);
			DependencyInjector.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
			DependencyInjector.GetService<DatabaseContext>().Seed();
		}
	}
}
