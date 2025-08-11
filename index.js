const express = require('express');
const app = express();
const port = process.env.PORT || 3000;

// Trasa główna: przekierowuje na repozytorium GitHub
app.get('/', (req, res) => {
  res.redirect(301, 'https://github.com/gabryssv/aura-lyrics');
});

// Trasa callback: obsługuje odpowiedź od Spotify
app.get('/callback', (req, res) => {
  const code = req.query.code;

  if (code) {
    // Jeśli jest kod, przekieruj do aplikacji desktopowej
    const appLink = `aura-lyrics://callback?code=${code}`;
    res.redirect(302, appLink);
  } else {
    // Jeśli nie ma kodu, wyświetl błąd
    res.status(400).send('Error: Authorization code not found in the request.');
  }
});

app.listen(port, () => {
  console.log(`Server listening on port ${port}`);
});

// Eksport aplikacji dla Vercel
module.exports = app;
