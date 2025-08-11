using SpotifyAPI.Web;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace AuraLyrics
{
    public partial class MainWindow : Window
    {
        private const string SpotifyClientId = "1d1be0b786094a81b7fe46699ff84f61";
        private const string SpotifyClientSecret = "fff1a439d64c45f5aa46d4c1d7207e89";
        private readonly Uri _redirectUri = new Uri("https://aura.gabryssv.tech/callback");
        private SpotifyClient _spotifyClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            var loginRequest = new LoginRequest(_redirectUri, SpotifyClientId, LoginRequest.ResponseType.Code)
            {
                Scope = new[] { Scopes.UserReadCurrentlyPlaying }
            };
            
            try
            {
                Process.Start(new ProcessStartInfo(loginRequest.ToUri().ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open browser for authorization: {ex.Message}");
            }
        }

        public async Task HandleAuthorizationCode(string code)
        {
            try
            {
                var response = await new OAuthClient().RequestToken(
                    new AuthorizationCodeTokenRequest(SpotifyClientId, SpotifyClientSecret, code, _redirectUri)
                );

                _spotifyClient = new SpotifyClient(response.AccessToken);

                Dispatcher.Invoke(() =>
                {
                    AuthorizeButton.Visibility = Visibility.Collapsed;
                    WelcomeMessage.Text = "Successfully authorized!";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling authorization code: {ex.Message}");
            }
        }

        private void ToggleOverlayButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for toggling the lyrics overlay will be implemented here.
        }
    }
}