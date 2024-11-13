using DevExpress.Maui;
using DevExpress.Maui.Core;

namespace DXMauiApp46 {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            ThemeManager.ApplyThemeToSystemBars = true;
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: true)
                .UseDevExpressControls()
                .UseDevExpressCollectionView()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                });
            DevExpress.Maui.CollectionView.Initializer.Init();
            DevExpress.Maui.Controls.Initializer.Init();
            return builder.Build();
        }
    }
}