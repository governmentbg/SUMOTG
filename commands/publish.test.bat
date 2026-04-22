RMDIR "C:\inetpub\HeatersTest\frontend" /S /Q
MKDIR "C:\inetpub\HeatersTest\frontend"
xcopy "C:\Projects\HeatersProject\Heaters\frontend\disttest" /E /H /R /X /Y /I /K  "C:\inetpub\HeatersTest\frontend"
CHDIR "C:\inetpub\HeatersTest\frontend"
MKDIR src
xcopy C:\inetpub\HeatersTest\frontend\assets /E /H /R /X /Y /I /K  C:\inetpub\HeatersTest\frontend\src\assets
move C:\inetpub\HeatersTest\frontend\web.config C:\inetpub\HeatersTest\frontend\src
pause
