-- Update Offers with Different Locations for Distance Testing
-- This script will update offers to have locations in different cities
-- so you can test distance calculations properly

USE OffersDb;
GO

-- First, let's see what offers we have and their current locations
SELECT 
    o.Id,
    o.Title,
    o.CategoryId,
    ol.Name as CurrentLocation,
    ol.Latitude,
    ol.Longitude
FROM Offers o
INNER JOIN OfferOfferLocation ool ON o.Id = ool.OffersId
INNER JOIN OfferLocations ol ON ool.LocationsId = ol.Id
WHERE o.CategoryId = 4  -- Travel and Tourism category
ORDER BY o.Id;
GO

-- Update some offers to have different locations for testing
-- Remove existing location relationships for specific offers
DELETE FROM OfferOfferLocation WHERE OffersId IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
GO

-- Add new location relationships to different cities
-- Offer 1 - Riyadh (same as user location - distance = 0)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (1, 1);
GO

-- Offer 2 - Jeddah (distance ~ 870 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (2, 2);
GO

-- Offer 3 - Dammam (distance ~ 390 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (3, 4);
GO

-- Offer 4 - Makkah (distance ~ 870 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (4, 5);
GO

-- Offer 5 - Madinah (distance ~ 850 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (5, 6);
GO

-- Offer 6 - Taif (distance ~ 800 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (6, 7);
GO

-- Offer 7 - Buraydah (distance ~ 330 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (7, 8);
GO

-- Offer 8 - Tabuk (distance ~ 650 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (8, 9);
GO

-- Offer 9 - Khamis Mushait (distance ~ 700 km)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (9, 10);
GO

-- Offer 10 - Riyadh again (distance = 0)
INSERT INTO OfferOfferLocation (OffersId, LocationsId) VALUES (10, 1);
GO

-- Verify the updated locations
SELECT 
    o.Id,
    o.Title,
    o.CategoryId,
    ol.Name as LocationName,
    ol.Latitude,
    ol.Longitude,
    CASE 
        WHEN ol.Latitude = 24.7136 AND ol.Longitude = 46.6753 THEN 'Same as User (0 km)'
        WHEN ol.Latitude = 21.4858 AND ol.Longitude = 39.1925 THEN 'Jeddah (~870 km)'
        WHEN ol.Latitude = 26.4207 AND ol.Longitude = 50.0888 THEN 'Dammam (~390 km)'
        WHEN ol.Latitude = 21.3891 AND ol.Longitude = 39.8579 THEN 'Makkah (~870 km)'
        WHEN ol.Latitude = 24.5247 AND ol.Longitude = 39.5692 THEN 'Madinah (~850 km)'
        WHEN ol.Latitude = 21.2703 AND ol.Longitude = 40.4158 THEN 'Taif (~800 km)'
        WHEN ol.Latitude = 26.3260 AND ol.Longitude = 43.9750 THEN 'Buraydah (~330 km)'
        WHEN ol.Latitude = 28.3838 AND ol.Longitude = 36.5550 THEN 'Tabuk (~650 km)'
        WHEN ol.Latitude = 18.3000 AND ol.Longitude = 42.7333 THEN 'Khamis Mushait (~700 km)'
        ELSE 'Other Location'
    END as ExpectedDistance
FROM Offers o
INNER JOIN OfferOfferLocation ool ON o.Id = ool.OffersId
INNER JOIN OfferLocations ol ON ool.LocationsId = ol.Id
WHERE o.CategoryId = 4 AND o.Id <= 10
ORDER BY o.Id;
GO

-- Test the distance calculation manually
DECLARE @UserLat FLOAT = 24.7136;
DECLARE @UserLon FLOAT = 46.6753;

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
