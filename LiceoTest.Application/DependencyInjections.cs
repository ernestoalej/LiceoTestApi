using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Application;

public static class DependencyInjections
{
	public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
	{
		////services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjections).Assembly));
		return services;
	}


}
