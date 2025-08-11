# Aura Lyrics

Aura Lyrics is a Windows desktop application that displays the lyrics of the currently playing song on Spotify in a clean, unobtrusive overlay.

## How It Works

1.  **Authorization**: The application uses Spotify's OAuth 2.0 to securely connect to your account. On the first run, you'll be prompted to log in and authorize the app.
2.  **Music Detection**: Once authorized, Aura Lyrics monitors the song currently playing on your Spotify account.
3.  **Lyrics Fetching**: It takes the song title and artist and uses the `LyricsScraperNET` library to find the corresponding lyrics.
4.  **Overlay Display**: The lyrics are shown in a simple, transparent, borderless overlay in the bottom-right corner of your screen. The overlay stays on top of other windows.
5.  **Control**: The main application window allows you to toggle the visibility of the lyrics overlay.

## Tech Stack

-   **Framework**: .NET 8 (WPF for UI)
-   **Language**: C#
-   **APIs & Libraries**:
    -   **Spotify Web API**: To get information about the currently playing track.
    -   **LyricsScraperNET**: To fetch song lyrics.
    -   **SpotifyAPI-NET**: A C# wrapper for the Spotify Web API to simplify integration.
-   **Authentication**: OAuth 2.0 (Authorization Code Flow)
-   **Deployment**:
    -   **Vercel**: Hosts the redirect page for the OAuth flow.
