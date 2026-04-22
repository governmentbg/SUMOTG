RMDIR "C:\inetpub\Heaters\frontend" /S /Q
MKDIR "C:\inetpub\Heaters\frontend"
xcopy "C:\Projects\HeatersProject\Heaters\frontend\dist" /E /H /R /X /Y /I /K  "C:\inetpub\Heaters\frontend"
CHDIR "C:\inetpub\Heaters\frontend"
MKDIR src
xcopy C:\inetpub\Heaters\frontend\assets /E /H /R /X /Y /I /K  C:\inetpub\Heaters\frontend\src\assets
move C:\inetpub\Heaters\frontend\web.config C:\inetpub\Heaters\frontend\src
pause
