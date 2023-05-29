using BlazorComponent;
using LiberalChat_desktop;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using Microsoft.Extensions.Logging;
using LiberalChat_desktop.src.data;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.RootComponents.Add<App>("#app");
        appBuilder.Services.AddMasaBlazor();

        var app = appBuilder.Build();

        app.MainWindow
            .SetTitle("LiberalChat desktop");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
        };

        app.Run();
    }
}