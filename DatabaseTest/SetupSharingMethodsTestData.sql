-- Setup test data for Offer Sharing Methods API
-- This script will create sample data in the OfferOfferSharingMethod junction table

USE OffersDb;
GO

-- First, let's check what offers and sharing methods we have
PRINT '=== CURRENT DATA ===';
PRINT 'Offers:';
SELECT Id, Title, IsActive FROM Offers WHERE Id BETWEEN 1 AND 10;

PRINT '';
PRINT 'Sharing Methods:';
SELECT Id, Name, Description, Icon, IsActive FROM OfferSharingMethods;

PRINT '';
PRINT 'Current Offer-SharingMethod relationships:';
SELECT 
    oosm.OffersId as OfferId,
    o.Title as OfferTitle,
    oosm.SharingMethodsId as SharingMethodId,
    osm.Name as SharingMethodName
FROM OfferOfferSharingMethod oosm
INNER JOIN Offers o ON oosm.OffersId = o.Id
INNER JOIN OfferSharingMethods osm ON oosm.SharingMethodsId = osm.Id
ORDER BY oosm.OffersId, oosm.SharingMethodsId;

-- Insert test relationships between offers and sharing methods
PRINT '';
PRINT '=== INSERTING TEST DATA ===';

-- Clear existing relationships for offers 1-10 (for clean testing)
DELETE FROM OfferOfferSharingMethod WHERE OffersId BETWEEN 1 AND 10;

-- Insert sharing method relationships for different offers
-- Offer 1: All sharing methods
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(1, 1), -- مشاركة مع التابعين
(1, 2), -- مشاركة مع منسوبي الأمانة
(1, 3), -- مشاركة على وسائل التواصل
(1, 4); -- رابط مباشر

-- Offer 2: Limited sharing methods
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(2, 1), -- مشاركة مع التابعين
(2, 3); -- مشاركة على وسائل التواصل

-- Offer 3: Social media and direct link only
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(3, 3), -- مشاركة على وسائل التواصل
(3, 4); -- رابط مباشر

-- Offer 4: Cannot be shared
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(4, 5); -- لا يمكن المشاركة

-- Offer 5: All sharing methods except cannot be shared
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(5, 1), -- مشاركة مع التابعين
(5, 2), -- مشاركة مع منسوبي الأمانة
(5, 3), -- مشاركة على وسائل التواصل
(5, 4); -- رابط مباشر

-- Offer 6: Only municipality employees
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(6, 2); -- مشاركة مع منسوبي الأمانة

-- Offer 7: Dependents and social media
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(7, 1), -- مشاركة مع التابعين
(7, 3); -- مشاركة على وسائل التواصل

-- Offer 8: Direct link only
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(8, 4); -- رابط مباشر

-- Offer 9: All sharing methods
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(9, 1), -- مشاركة مع التابعين
(9, 2), -- مشاركة مع منسوبي الأمانة
(9, 3), -- مشاركة على وسائل التواصل
(9, 4); -- رابط مباشر

-- Offer 10: Cannot be shared
INSERT INTO OfferOfferSharingMethod (OffersId, SharingMethodsId) VALUES
(10, 5); -- لا يمكن المشاركة

PRINT 'Test data inserted successfully!';

-- Verify the inserted data
PRINT '';
PRINT '=== VERIFICATION ===';
PRINT 'Updated Offer-SharingMethod relationships:';
SELECT 
    oosm.OffersId as OfferId,
    o.Title as OfferTitle,
    oosm.SharingMethodsId as SharingMethodId,
    osm.Name as SharingMethodName,
    osm.Icon as Icon
FROM OfferOfferSharingMethod oosm
INNER JOIN Offers o ON oosm.OffersId = o.Id
INNER JOIN OfferSharingMethods osm ON oosm.SharingMethodsId = osm.Id
WHERE oosm.OffersId BETWEEN 1 AND 10
ORDER BY oosm.OffersId, oosm.SharingMethodsId;

-- Summary by offer
PRINT '';
PRINT '=== SUMMARY BY OFFER ===';
SELECT 
    o.Id as OfferId,
    o.Title as OfferTitle,
    COUNT(oosm.SharingMethodsId) as SharingMethodCount,
    STRING_AGG(osm.Name, ', ') as SharingMethods
FROM Offers o
LEFT JOIN OfferOfferSharingMethod oosm ON o.Id = oosm.OffersId
LEFT JOIN OfferSharingMethods osm ON oosm.SharingMethodsId = osm.Id
WHERE o.Id BETWEEN 1 AND 10
GROUP BY o.Id, o.Title
ORDER BY o.Id;

PRINT '';
PRINT '=== READY FOR TESTING ===';
PRINT 'You can now test the API with the following offer IDs:';
PRINT '- Offer 1: 4 sharing methods (all except cannot be shared)';
PRINT '- Offer 2: 2 sharing methods (dependents + social media)';
PRINT '- Offer 3: 2 sharing methods (social media + direct link)';
PRINT '- Offer 4: 1 sharing method (cannot be shared)';
PRINT '- Offer 5: 4 sharing methods (all except cannot be shared)';
PRINT '- Offer 6: 1 sharing method (municipality employees only)';
PRINT '- Offer 7: 2 sharing methods (dependents + social media)';
PRINT '- Offer 8: 1 sharing method (direct link only)';
PRINT '- Offer 9: 4 sharing methods (all except cannot be shared)';
PRINT '- Offer 10: 1 sharing method (cannot be shared)';
