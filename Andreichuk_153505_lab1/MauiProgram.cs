using Microsoft.Extensions.Logging;
using System;
using Andreichuk_153505_lab1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Andreichuk_153505_lab1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddSingleton<AudioDB>();

        return builder.Build();
	}
}
