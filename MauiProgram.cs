using M_Hike_hk3971t_gre.ac.uk.Views;
using M_Hike_hk3971t_gre.ac.uk.ViewModels;
using Microsoft.Extensions.Logging;
using M_Hike_hk3971t_gre.ac.uk.Services;

namespace M_Hike_hk3971t_gre.ac.uk
{
    // Static class for creating the Maui app
    public static class MauiProgram
    {
        // Method to create the Maui app
        public static MauiApp CreateMauiApp()
        {
            // Create a MauiApp builder
            var builder = MauiApp.CreateBuilder();

            // Use the specified Maui app class (App)
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Configure fonts for the app
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Add debug logging in DEBUG mode
            builder.Logging.AddDebug();
#endif

            // Services Registration
            // Register the IHikeService implementation (HikeService) as a singleton
            builder.Services.AddSingleton<IHikeService, HikeService>();

            // Views Registration
            // Register the HikeListPage and AddUpdateHikeDetail views
            builder.Services.AddSingleton<HikeListPage>();
            builder.Services.AddTransient<AddUpdateHikeDetail>();

            // View Models Registration
            // Register the HikeListPageViewModel and AddUpdateHikeDetailViewModel as singleton and transient, respectively
            builder.Services.AddSingleton<HikeListPageViewModel>();
            builder.Services.AddTransient<AddUpdateHikeDetailViewModel>();

            // Build and return the MauiApp
            return builder.Build();
        }
    }
}
