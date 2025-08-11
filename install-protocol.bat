@echo off
SET "PROTOCOL_NAME=aura-lyrics"
SET "APP_NAME=AuraLyrics"
REM This path needs to point to the location of your final executable
SET "APP_PATH=%~dp0bin\Debug\net8.0-windows\AuraLyrics.exe"

echo Adding protocol handler for %PROTOCOL_NAME%...

REG ADD "HKEY_CURRENT_USER\Software\Classes\%PROTOCOL_NAME%" /v "URL Protocol" /t REG_SZ /d "" /f
REG ADD "HKEY_CURRENT_USER\Software\Classes\%PROTOCOL_NAME%" /ve /t REG_SZ /d "URL:%APP_NAME% Protocol" /f
REG ADD "HKEY_CURRENT_USER\Software\Classes\%PROTOCOL_NAME%\shell" /ve /t REG_SZ /d "" /f
REG ADD "HKEY_CURRENT_USER\Software\Classes\%PROTOCOL_NAME%\shell\open" /ve /t REG_SZ /d "" /f
REG ADD "HKEY_CURRENT_USER\Software\Classes\%PROTOCOL_NAME%\shell\open\command" /ve /t REG_SZ /d ""%APP_PATH%" "%%1"" /f

echo.

echo Protocol handler for %PROTOCOL_NAME% has been installed.
echo Make sure the APP_PATH is correct: %APP_PATH%
pause
