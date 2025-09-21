@echo off
dotnet ef database update --project Persistence\Persistence.csproj --startup-project Presentation\Presentation.csproj
pause
