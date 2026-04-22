cd "C:\Projects\HeatersProject\Heaters_v1.0\frontend"
RMDIR "C:\Projects\HeatersProject\Heaters_v1.0\frontend\dist" /S /Q

ng build --configuration production --delete-output-path --outputHashing=all
