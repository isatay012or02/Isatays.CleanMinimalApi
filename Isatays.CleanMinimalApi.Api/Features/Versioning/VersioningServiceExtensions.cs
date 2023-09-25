using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Isatays.CleanMinimalApi.Api.Features.Versioning;

/// <summary>
/// Ресширение версионирования для добавления в сборку
/// </summary>
public static class VersioningServiceExtensions
{
	/// <summary>
	/// Добавляет возможность использовать версионирование веб апи
	/// Настраивает стандарную версию 1.0
	/// Настраивает возможность сегментированного версионирования
	/// </summary>
	/// <param name = "services"> </param>
	/// <returns> </returns>
	public static IServiceCollection AddConfiguredVersioning(this IServiceCollection services)
	{
		services.AddApiVersioning(options =>
		{
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.DefaultApiVersion = new ApiVersion(1, 0);
			options.ReportApiVersions = true;
			options.ApiVersionReader = new UrlSegmentApiVersionReader();
		});

		services.AddVersionedApiExplorer(options =>
		{
			options.ApiVersionParameterSource = new UrlSegmentApiVersionReader();
		});

		return services;
	}
}