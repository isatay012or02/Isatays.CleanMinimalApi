namespace Isatays.CleanMinimalApi.Api.Features.Versioning;

/// <summary>
/// Расширение для IApplicationBuilder
/// </summary>
public static class VersioningApplicationBuilder
{
	/// <summary>
	/// Добавляет в пайплайн версионирование
	/// </summary>
	/// <param name="app"></param>
	/// <returns></returns>
	public static IApplicationBuilder UseConfiguredVersioning(this IApplicationBuilder app)
	{
		app.UseApiVersioning();

		return app;
	}
}