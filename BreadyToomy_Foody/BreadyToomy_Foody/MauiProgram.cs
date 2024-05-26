using Microsoft.Extensions.DependencyInjection;
using BreadyToomy_Foody.Data;

namespace BreadyToomy_Foody
{
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

            // Register the DbContext
            builder.Services.AddDbContext<BreadyToomyContext>();

            // Register view models
            builder.Services.AddTransient<ProductManagementViewModel>();
            // Register other view models as needed

            return builder.Build();
        }
    }
}
