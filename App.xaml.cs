using System.Linq;
using System.Windows;

namespace AuraLyrics
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            mainWindow.Show();

            if (e.Args.Length > 0)
            {
                var uri = e.Args[0];
                if (uri.StartsWith("aura-lyrics://callback?code="))
                {
                    var code = uri.Split('=')[1];
                    _ = mainWindow.HandleAuthorizationCode(code);
                }
            }
        }
    }
}