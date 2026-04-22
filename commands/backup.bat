ECHO OFF
:: set path to save backup files e.g. D:\backup
set BACKUPPATH=C:\Projects\HeatersProject\database

:: remove old files
pushd "%BACKUPPATH%"
for %%X in (bak) do (
  set "skip=1"
  for /f "skip=5 delims=" %%F in ('dir /b /a-d /o-d /tw *.%%X') do (
    if defined skip forfiles /d -7 /m "%%F" >nul 2>nul && set "skip="
    if not defined skip del "%%F" 
  )
)  


:: set name of the server and instance
set SERVERNAME=localhost

:: set database name
set DATABASENAME=heaters

:: filename format Name-Date
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ("%TIME%") do (set mytime=%%a%%b)

set DATESTAMP=%mydate%_%mytime%
set BACKUPFILENAME=%BACKUPPATH%\%DATABASENAME%-%DATESTAMP%.bak

SqlCmd -E -S %SERVERNAME% -d master -Q "BACKUP DATABASE [%DATABASENAME%] TO DISK = N'%BACKUPFILENAME%' WITH NOFORMAT, INIT, SKIP, NOREWIND, NOUNLOAD,  STATS = 10, NAME = N'%DATABASENAME% backup';"
ECHO.