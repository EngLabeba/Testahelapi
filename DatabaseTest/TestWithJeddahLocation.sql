-- Test Data with User Location in Jeddah
-- This script sets up test data for API testing with Jeddah as user location

USE OffersDb;
GO

-- Jeddah coordinates: 21.4858, 39.1925
-- Let's see what offers we have and their current locations
SELECT 
    o.Id,
    o.Title,
    o.CategoryId,
    ol.Name as CurrentLocation,
    ol.Latitude,
    ol.Longitude,
    CASE 
        WHEN ol.Latitude = 21.4858 AND ol.Longitude = 39.1925 THEN 'Same as User (0 km)'
        WHEN ol.Latitude = 24.7136 AND ol.Longitude = 46.6753 THEN 'Riyadh (~870 km)'
        WHEN ol.Latitude = 26.4207 AND ol.Longitude = 50.0888 THEN 'Dammam (~1200 km)'
        WHEN ol.Latitude = 21.3891 AND ol.Longitude = 39.8579 THEN 'Makkah (~65 km)'
        WHEN ol.Latitude = 24.5247 AND ol.Longitude = 39.5692 THEN 'Madinah (~350 km)'
        WHEN ol.Latitude = 21.2703 AND ol.Longitude = 40.4158 THEN 'Taif (~70 km)'
        WHEN ol.Latitude = 26.3260 AND ol.Longitude = 43.9750 THEN 'Buraydah (~1200 km)'
        WHEN ol.Latitude = 28.3838 AND ol.Longitude = 36.5550 THEN 'Tabuk (~500 km)'
        WHEN ol.Latitude = 18.3000 AND ol.Longitude = 42.7333 THEN 'Khamis Mushait (~400 km)'
        ELSE 'Other Location'
    END as DistanceFromJeddah
FROM Offers o
INNER JOIN OfferOfferLocation ool ON o.Id = ool.OffersId
INNER JOIN OfferLocations ol ON ool.LocationsId = ol.Id
WHERE o.CategoryId = 4 AND o.Id <= 10
ORDER BY o.Id;
GO

-- Test the distance calculation manually from Jeddah
DECLARE @UserLat FLOAT = 21.4858;  -- Jeddah latitude
DECLARE @UserLon FLOAT = 39.1925;  -- Jeddah longitude

SELECT 
    o.Id,
    o.Title,
    ol.Name as LocationName,
    ol.Latitude,
    ol.Longitude,
    CASE 
        WHEN ol.Latitude IS NOT NULL AND ol.Longitude IS NOT NULL 
        THEN ROUND(
            6371 * ACOS(
                COS(RADIANS(@UserLat)) * 
                COS(RADIANS(ol.Latitude)) * 
                COS(RADIANS(ol.Longitude) - RADIANS(@UserLon)) + 
                SIN(RADIANS(@UserLat)) * 
                SIN(RADIANS(ol.Latitude))
            ), 2
        )
        ELSE NULL
    END as CalculatedDistanceKm
FROM Offers o
INNER JOIN OfferOfferLocation ool ON o.Id = ool.OffersId
INNER JOIN OfferLocations ol ON ool.LocationsId = ol.Id
WHERE o.CategoryId = 4 AND o.Id <= 10
ORDER BY o.Id;
GO
