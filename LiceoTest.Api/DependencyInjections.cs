using LiceoTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LiceoTest.API;

public static class DependencyInjections
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration, bool isDevelopment)
	{
		// TODO: por ahora no se hace nada con el isDevelopment

		ArgumentNullException.ThrowIfNull(configuration, nameof(ConfigurationDebugViewContext));
		ArgumentNullException.ThrowIfNull(configuration);

		Console.WriteLine(configuration["DbConnectionString"]);

		services.AddDbContext<ApplicationContext>(options =>
			options.UseSqlServer(configuration["DbConnectionString"]).EnableSensitiveDataLogging(false));

	
		return services;
	}
}
