cd "C:\Projects\HeatersProject\Heaters\frontend"
RMDIR "C:\Projects\HeatersProject\Heaters\frontend\disttest" /S /Q

ng build --configuration test ---delete-output-path --outputHashing=all --output-path=disttest
