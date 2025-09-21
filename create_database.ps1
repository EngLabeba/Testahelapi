# PowerShell script to create the database
Write-Host "Creating database with Entity Framework migrations..."

# Run the database update command
dotnet ef database update --project "Persistence\Persistence.csproj" --startup-project "Presentation\Presentation.csproj"

Write-Host "Database creation completed!"
