@echo off
echo Applying OfferUsage table migration...
dotnet ef database update --project Persistence\Persistence.csproj --startup-project Presentation\Presentation.csproj
echo Migration completed!
pause
