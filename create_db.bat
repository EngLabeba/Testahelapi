@echo off
echo Creating database...
dotnet ef database update --project .\Persistence\Persistence.csproj --startup-project .\Presentation\Presentation.csproj
echo Database creation completed!
pause
