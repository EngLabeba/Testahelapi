-- Verify that test data was updated correctly
-- Run this after UpdateOfferTestData.sql to check the results

USE OffersDb;
GO

-- Check CurrentUses data (for MaxUsed filter testing)
PRINT '=== CURRENT USES DATA (for MaxUsed filter) ===';
SELECT 
    Id,
    Title,
    CurrentUses,
    CategoryId,
    'Expected Order' = ROW_NUMBER() OVER (ORDER BY CurrentUses DESC)
FROM Offers 
WHERE Id BETWEEN 1 AND 15
ORDER BY CurrentUses DESC;

PRINT '';
PRINT '=== RATING DATA (for HigherEvaluation filter) ===';
-- Check Rating data (for HigherEvaluation filter testing)
SELECT 
    Id,
    Title,
    Rating,
    RatingCount,
    CategoryId,
    'Expected Order' = ROW_NUMBER() OVER (ORDER BY Rating DESC)
FROM Offers 
WHERE Id BETWEEN 1 AND 15
ORDER BY Rating DESC;

PRINT '';
PRINT '=== CATEGORY DISTRIBUTION ===';
-- Check category distribution
SELECT 
    CategoryId,
    COUNT(*) as OfferCount,
    AVG(CAST(CurrentUses AS FLOAT)) as AvgCurrentUses,
    AVG(CAST(Rating AS FLOAT)) as AvgRating
FROM Offers 
WHERE Id BETWEEN 1 AND 15
GROUP BY CategoryId
ORDER BY CategoryId;

PRINT '';
PRINT '=== TEST DATA SUMMARY ===';
PRINT 'MaxUsed Filter Test:';
PRINT '- Highest CurrentUses: ' + CAST((SELECT MAX(CurrentUses) FROM Offers WHERE Id BETWEEN 1 AND 15) AS VARCHAR);
PRINT '- Lowest CurrentUses: ' + CAST((SELECT MIN(CurrentUses) FROM Offers WHERE Id BETWEEN 1 AND 15) AS VARCHAR);

PRINT '';
PRINT 'HigherEvaluation Filter Test:';
PRINT '- Highest Rating: ' + CAST((SELECT MAX(Rating) FROM Offers WHERE Id BETWEEN 1 AND 15) AS VARCHAR);
PRINT '- Lowest Rating: ' + CAST((SELECT MIN(Rating) FROM Offers WHERE Id BETWEEN 1 AND 15) AS VARCHAR);

PRINT '';
PRINT '=== READY FOR TESTING ===';
PRINT 'You can now test the filtered offers API with the following scenarios:';
PRINT '1. MaxUsed filter (filterType: 3) - should order by CurrentUses DESC';
PRINT '2. HigherEvaluation filter (filterType: 4) - should order by Rating DESC';
PRINT '3. LastInserted filter (filterType: 2) - should order by CreatedAt DESC';
PRINT '4. NearestLocation filter (filterType: 1) - should order by distance';
