Stwórz w C# i .NET SDK 8 aplikację na Windows o nazwie **Aura Lyrics**.

Aplikacja ma działać w następujący sposób:
- Jest to aplikacja typu Windows Desktop, ale nakładka (overlay) wyświetla tylko tekst aktualnej wersji piosenki w prawym dolnym rogu ekranu na przezroczystym tle (bez ramki, zawsze na wierzchu).
- Informacje o aktualnie odtwarzanej muzyce pobiera przez **OAuth 2.0** z oficjalnego Spotify Web API.
- Teksty piosenek pobiera przez bibliotekę **LyricsScraperNET**.
- Po uruchomieniu aplikacji wyświetla się **strona główna**:
    - Jeśli użytkownik nie jest zalogowany → widoczne przywitanie i przycisk „Authorize”.
    - Jeśli użytkownik jest zalogowany i gra utwór → pokazuje jego tytuł (jeśli nic nie gra, nie pokazuje nic).
    - Zawsze na stronie głównej jest przycisk „Toggle Overlay” (który włącza lub wyłącza overlay z tekstem piosenki).
- Cała aplikacja, UI i komunikaty są w języku **angielskim**.
- Autoryzacja odbywa się poprzez **Redirect URI** ustawione na moją domenę `aura.gabryssv.tech`.
- Na tej domenie będzie hostowana na **Vercel** prosta strona, która po autoryzacji w Spotify pokaże komunikat w przeglądarce „Open Aura Lyrics app” i po kliknięciu „OK” wyśle dane autoryzacyjne z powrotem do aplikacji.
- Jeśli ktoś wejdzie bezpośrednio na `aura.gabryssv.tech` (bez procesu autoryzacji), strona natychmiast przekieruje go na repozytorium GitHub: `https://github.com/gabryssv/aura-lyrics`.

---

**Instrukcja krok po kroku:**
1. Na początku przedstaw mi **czynności zewnętrzne**, które mam wykonać:
    - Utworzenie aplikacji w **Spotify Developer Dashboard** z podaniem Redirect URI `https://aura.gabryssv.tech/callback`.
    - Utworzenie nowego projektu na **Vercel** z prostą stroną HTML/JS, która po autoryzacji przekieruje użytkownika do aplikacji Windows (np. przy użyciu custom URL scheme lub lokalnego serwera nasłuchującego).  
      Strona ma także zawierać przekierowanie na repo GitHub, jeśli ktoś odwiedzi ją bezpośrednio.
    - Podpięcie domeny `aura.gabryssv.tech` do projektu na Vercel (wytłumacz mi, jak ustawić rekordy DNS).
2. Gdy te czynności wykonam, podam Ci dane:
    - Client ID
    - Client Secret
    - Redirect URI
3. Następnie rozpocznij implementację aplikacji krok po kroku.
4. Po każdym kroku zatrzymaj się i czekaj, aż napiszę „dalej”.
5. Na końcu każdego kroku wykonaj commit do GitHub (repozytorium o nazwie `aura-lyrics`, które utworzysz na moim koncie przez terminal) na **branchu master**, używając formatu:

git commit -m "feat: opis zmian" - lub "fix:" itd.

Znacznik  Znaczenie
feat: Dodanie nowej funkcji lub feature’a
fix:  Naprawa błędu
docs: Zmiana w dokumentacji (README, wiki itp.)
style:  Zmiany w formatowaniu/kodzie bez wpływu na logikę (np. spacje, średniki)
refactor: Przebudowa kodu bez zmiany działania (np. poprawa struktury)
perf: Optymalizacja wydajności
test: Dodanie lub poprawa testów
build:  Zmiany w systemie budowania lub zależnościach
ci: Zmiany w konfiguracji CI/CD
chore:  Zadania porządkowe, które nie zmieniają kodu aplikacji
revert: Cofnięcie wcześniejszego commita

Format przykładowego commita:

feat(login): add password reset functionality  
fix(api): handle null values in response  
docs(readme): update installation instructions

6. Repozytorium ma być od początku zainicjalizowane w Git, połączone z GitHub, ustawione na branchu master i gotowe do pracy.
7. Przy tworzeniu repozytorium od razu dodaj plik **README.md** opisujący projekt:
    - Od strony technologicznej (jakie biblioteki, API, narzędzia zostały użyte).
    - Od strony działania (jak działa aplikacja, co robi krok po kroku).

---

**Etapy implementacji**:
- **Krok 1**: Konfiguracja projektu w Visual Studio lub przez `dotnet new`, dodanie podstawowych plików, przygotowanie architektury projektu (UI, logika OAuth, logika overlay).
- **Krok 2**: Implementacja strony głównej z przyciskiem autoryzacji Spotify.
- **Krok 3**: Integracja z Spotify OAuth 2.0, odbiór tokenu w aplikacji po autoryzacji w przeglądarce.
- **Krok 4**: Połączenie z LyricsScraperNET — pobieranie tekstów na podstawie tytułu i wykonawcy.
- **Krok 5**: Implementacja nakładki (transparentne tło, prawy dolny róg, zawsze na wierzchu) i mechanizm aktualizacji tekstu w czasie rzeczywistym.
- **Krok 6**: Dodanie przycisku włącz/wyłącz overlay na stronie głównej.
- **Krok 7**: Finalne testy, poprawki, optymalizacja.

---

**Uwagi**:
- Cały kod pisz w C# z wykorzystaniem .NET 8.
- Projekt ma działać w Windows 10+.
- Overlay ma być lekki i nie przeszkadzać w pracy użytkownika.
- Pisz czytelny, dobrze skomentowany kod.
- Przy każdej nowej funkcji od razu przygotuj commit i opisuj zmiany w commit message.