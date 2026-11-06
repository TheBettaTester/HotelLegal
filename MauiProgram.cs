
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using System.IO;
#endif

namespace MauiAppHotel
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
                    fonts.AddFont("Kalam-Bold.ttf", "KalamBold");
                    fonts.AddFont("Kalam-Light.ttf", "KalamLight");
                    fonts.AddFont("Kalam-Regular.ttf", "Kalam");
                });

            builder.ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
                events.AddWindows(windows =>
                {
                    windows.OnWindowCreated(window =>
                    {
                        System.Diagnostics.Debug.WriteLine(
                            "JANELA DO HOTEL LEGAL FOI CRIADA!"
                        );

                        try
                        {
                            IntPtr hwnd =
                                WindowNative.GetWindowHandle(window);

                            WindowId windowId =
                                Win32Interop.GetWindowIdFromWindow(hwnd);

                            AppWindow appWindow =
                                AppWindow.GetFromWindowId(windowId);

                            string caminhoIcone = Path.Combine(
                                AppContext.BaseDirectory,
                                "appicon.ico"
                            );

                            if (File.Exists(caminhoIcone))
                            {
                                appWindow.SetIcon(caminhoIcone);

                                System.Diagnostics.Debug.WriteLine(
                                    "ÍCONE ENCONTRADO E CONFIGURADO: " +
                                    caminhoIcone
                                );
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine(
                                    "ÍCONE NÃO ENCONTRADO: " +
                                    caminhoIcone
                                );
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(
                                "ERRO AO CONFIGURAR ÍCONE: " +
                                ex.ToString()
                            );
                        }
                    });
                });
#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
