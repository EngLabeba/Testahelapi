-- Update CurrentUses and Rating fields for testing filtered offers API
-- This script will populate test data for MaxUsed and HigherEvaluation filters

USE OffersDb;
GO

-- Update CurrentUses field for different offers to test MaxUsed filter
-- Higher values = more used offers
UPDATE Offers 
SET CurrentUses = CASE 
    WHEN Id = 1 THEN 150  -- Most used offer
    WHEN Id = 2 THEN 89   -- Second most used
    WHEN Id = 3 THEN 45   -- Medium usage
    WHEN Id = 4 THEN 120  -- High usage
    WHEN Id = 5 THEN 23   -- Low usage
    WHEN Id = 6 THEN 78   -- Good usage
    WHEN Id = 7 THEN 200  -- Highest usage
    WHEN Id = 8 THEN 12   -- Very low usage
    WHEN Id = 9 THEN 95   -- High usage
    WHEN Id = 10 THEN 67  -- Medium-high usage
    WHEN Id = 11 THEN 34  -- Medium usage
    WHEN Id = 12 THEN 156 -- Very high usage
    WHEN Id = 13 THEN 8   -- Very low usage
    WHEN Id = 14 THEN 112 -- High usage
    WHEN Id = 15 THEN 43  -- Medium usage
    ELSE CurrentUses
END
WHERE Id BETWEEN 1 AND 15;

-- Update Rating field for different offers to test HigherEvaluation filter
-- Higher values = better rated offers (0-5 scale)
UPDATE Offers 
SET Rating = CASE 
    WHEN Id = 1 THEN 4.8   -- Excellent rating
    WHEN Id = 2 THEN 3.2   -- Good rating
    WHEN Id = 3 THEN 4.5   -- Very good rating
    WHEN Id = 4 THEN 2.1   -- Poor rating
    WHEN Id = 5 THEN 4.9   -- Excellent rating
    WHEN Id = 6 THEN 3.7   -- Good rating
    WHEN Id = 7 THEN 4.2   -- Very good rating
    WHEN Id = 8 THEN 1.8   -- Poor rating
    WHEN Id = 9 THEN 4.6   -- Very good rating
    WHEN Id = 10 THEN 3.4  -- Good rating
    WHEN Id = 11 THEN 4.7  -- Excellent rating
    WHEN Id = 12 THEN 2.9  -- Fair rating
    WHEN Id = 13 THEN 4.3  -- Very good rating
    WHEN Id = 14 THEN 3.8  -- Good rating
    WHEN Id = 15 THEN 4.1  -- Very good rating
    ELSE Rating
END
WHERE Id BETWEEN 1 AND 15;

-- Update RatingCount field to show number of ratings
UPDATE Offers 
SET RatingCount = CASE 
    WHEN Id = 1 THEN 45   -- Many ratings
    WHEN Id = 2 THEN 23   -- Some ratings
    WHEN Id = 3 THEN 67   -- Many ratings
    WHEN Id = 4 THEN 12   -- Few ratings
    WHEN Id = 5 THEN 89   -- Many ratings
    WHEN Id = 6 THEN 34   -- Some ratings
    WHEN Id = 7 THEN 56   -- Many ratings
    WHEN Id = 8 THEN 8    -- Very few ratings
    WHEN Id = 9 THEN 78   -- Many ratings
    WHEN Id = 10 THEN 29  -- Some ratings
    WHEN Id = 11 THEN 92  -- Many ratings
    WHEN Id = 12 THEN 18  -- Few ratings
    WHEN Id = 13 THEN 41  -- Some ratings
    WHEN Id = 14 THEN 35  -- Some ratings
    WHEN Id = 15 THEN 63  -- Many ratings
    ELSE RatingCount
END
WHERE Id BETWEEN 1 AND 15;

-- Display the updated data for verification
SELECT 
    Id,
    Title,
    CurrentUses,
    Rating,
    RatingCount,
    CategoryId,
    CreatedAt
FROM Offers 
WHERE Id BETWEEN 1 AND 15
ORDER BY Id;

PRINT 'Test data updated successfully!';
PRINT 'CurrentUses field: Higher values = more used offers';
PRINT 'Rating field: Higher values = better rated offers (0-5 scale)';
PRINT 'RatingCount field: Number of ratings received';
