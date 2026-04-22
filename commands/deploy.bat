cd "C:\Projects\HeatersProject\Heaters\frontend"
RMDIR "C:\Projects\HeatersProject\Heaters\frontend\dist" /S /Q

ng build --configuration production --delete-output-path --outputHashing=all
