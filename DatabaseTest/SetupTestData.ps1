# PowerShell script to set up test data for filtered offers API
# This script will update the database with test data and verify the results

Write-Host "=== Setting up test data for Filtered Offers API ===" -ForegroundColor Green

# Set the database connection parameters
$ServerInstance = "."
$Database = "OffersDb"

Write-Host "Updating CurrentUses and Rating fields..." -ForegroundColor Yellow

try {
    # Run the SQL script to update test data
    $UpdateScript = Get-Content -Path "UpdateOfferTestData.sql" -Raw
    Invoke-Sqlcmd -ServerInstance $ServerInstance -Database $Database -Query $UpdateScript
    
    Write-Host "✅ Test data updated successfully!" -ForegroundColor Green
    
    Write-Host "Verifying test data..." -ForegroundColor Yellow
    
    # Run the verification script
    $VerifyScript = Get-Content -Path "VerifyTestData.sql" -Raw
    $Results = Invoke-Sqlcmd -ServerInstance $ServerInstance -Database $Database -Query $VerifyScript
    
    Write-Host "✅ Test data verification completed!" -ForegroundColor Green
    
    Write-Host "`n=== TEST DATA READY ===" -ForegroundColor Cyan
    Write-Host "You can now test the filtered offers API with the following scenarios:" -ForegroundColor White
    Write-Host "1. MaxUsed filter (filterType: 3) - orders by CurrentUses DESC" -ForegroundColor White
    Write-Host "2. HigherEvaluation filter (filterType: 4) - orders by Rating DESC" -ForegroundColor White
    Write-Host "3. LastInserted filter (filterType: 2) - orders by CreatedAt DESC" -ForegroundColor White
    Write-Host "4. NearestLocation filter (filterType: 1) - orders by distance" -ForegroundColor White
    
    Write-Host "`n=== SAMPLE API REQUESTS ===" -ForegroundColor Cyan
    Write-Host "MaxUsed Filter:" -ForegroundColor Yellow
    Write-Host 'POST /api/Offers/get-filtered-offers' -ForegroundColor Gray
    Write-Host '{"paginationInput":{"currentPage":1,"takenRows":5},"filterType":3}' -ForegroundColor Gray
    
    Write-Host "`nHigherEvaluation Filter:" -ForegroundColor Yellow
    Write-Host 'POST /api/Offers/get-filtered-offers' -ForegroundColor Gray
    Write-Host '{"paginationInput":{"currentPage":1,"takenRows":5},"filterType":4}' -ForegroundColor Gray
    
} catch {
    Write-Host "❌ Error setting up test data: $($_.Exception.Message)" -ForegroundColor Red
    Write-Host "Make sure SQL Server is running and the OffersDb database exists." -ForegroundColor Yellow
}
