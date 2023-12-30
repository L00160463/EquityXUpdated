using Microcharts.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Extensions.Logging;
using EquityX_L00160463.Services;
using EquityX_L00160463.ViewModels;
using EquityX_L00160463.View;

namespace EquityX_L00160463
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAssetDataService, AssetDataService>();

            builder.Services.AddTransient<AssetViewModel>();

            builder.Services.AddTransient<BindingTest>();

            builder.Services.AddTransient<Home>();

            builder.Services.AddTransient<Stocks>();

            builder.Services.AddTransient<Crypto>();




#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}