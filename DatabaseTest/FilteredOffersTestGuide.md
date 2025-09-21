# Filtered Offers API Test Guide

## 🎯 Overview
This guide provides comprehensive test data and examples for the new `get-filtered-offers` API endpoint.

## 📋 Prerequisites
1. SQL Server running with OffersDb database
2. Updated database with test data
3. API running and accessible

## 🚀 Quick Setup

### Option 1: PowerShell Script (Recommended)
```powershell
cd DatabaseTest
.\SetupTestData.ps1
```

### Option 2: Manual SQL Execution
```sql
-- Run these SQL scripts in order:
1. UpdateOfferTestData.sql
2. VerifyTestData.sql
```

## 📊 Test Data Summary

### CurrentUses Field (for MaxUsed filter)
| Offer ID | CurrentUses | Expected Order |
|----------|-------------|----------------|
| 7        | 200         | 1st (highest)  |
| 12       | 156         | 2nd            |
| 1        | 150         | 3rd            |
| 4        | 120         | 4th            |
| 9        | 95          | 5th            |

### Rating Field (for HigherEvaluation filter)
| Offer ID | Rating | Expected Order |
|----------|--------|----------------|
| 5        | 4.9    | 1st (highest)  |
| 1        | 4.8    | 2nd            |
| 11       | 4.7    | 3rd            |
| 9        | 4.6    | 4th            |
| 3        | 4.5    | 5th            |

## 🧪 Test Scenarios

### 1. NoFilter Test
**Purpose**: Verify offers are returned with default ordering (by Id)

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": null,
  "userId": "user404",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 0
}
```

**Expected Result**: 
- Offers ordered by Id (ascending order)
- Offer ID 1 should be first, then 2, 3, 4, 5...

### 2. MaxUsed Filter Test
**Purpose**: Verify offers are ordered by CurrentUses (most used first)

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": null,
  "userId": "user123",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 3
}
```

**Expected Result**: 
- Offer ID 7 (200 uses) should be first
- Offer ID 12 (156 uses) should be second
- Offer ID 1 (150 uses) should be third

### 2. HigherEvaluation Filter Test
**Purpose**: Verify offers are ordered by Rating (highest rating first)

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": null,
  "userId": "user456",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 4
}
```

**Expected Result**:
- Offer ID 5 (4.9 rating) should be first
- Offer ID 1 (4.8 rating) should be second
- Offer ID 11 (4.7 rating) should be third

### 3. MaxUsed Filter with Category
**Purpose**: Verify category filtering works with MaxUsed ordering

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 3,
    "count": 3,
    "getAll": false
  },
  "categoryId": 4,
  "userId": "user789",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 3
}
```

**Expected Result**: Only offers from category 4, ordered by CurrentUses

### 4. HigherEvaluation Filter with Category
**Purpose**: Verify category filtering works with HigherEvaluation ordering

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 3,
    "count": 3,
    "getAll": false
  },
  "categoryId": 2,
  "userId": "user101",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 4
}
```

**Expected Result**: Only offers from category 2, ordered by Rating

### 5. LastInserted Filter Test
**Purpose**: Verify offers are ordered by creation date (newest first)

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": null,
  "userId": "user202",
  "userLatitude": null,
  "userLongitude": null,
  "filterType": 2
}
```

**Expected Result**: Offers ordered by CreatedAt descending

### 6. NearestLocation Filter Test
**Purpose**: Verify offers are ordered by distance from user location

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": null,
  "userId": "user303",
  "userLatitude": 21.4858,
  "userLongitude": 39.1925,
  "filterType": 1
}
```

**Expected Result**: Offers ordered by distance from Jeddah (21.4858, 39.1925)

### 7. Invalid Coordinates Test (0,0)
**Purpose**: Verify that distanceInKm is null when coordinates are (0,0)

**Request**:
```json
POST /api/Offers/get-filtered-offers
{
  "paginationInput": {
    "currentPage": 1,
    "takenRows": 5,
    "count": 5,
    "getAll": false
  },
  "categoryId": 4,
  "userId": "user123",
  "userLatitude": 0,
  "userLongitude": 0,
  "filterType": 3
}
```

**Expected Result**: 
- distanceInKm should be null for all offers
- No distance calculation should be performed
- Offers should still be ordered by the specified filter type (MaxUsed in this case)

## 🔍 Verification Checklist

### NoFilter (filterType: 0)
- [ ] Offers are ordered by Id ascending
- [ ] Offer ID 1 appears first
- [ ] Offer ID 2 appears second
- [ ] Offer ID 3 appears third

### MaxUsed Filter (filterType: 3)
- [ ] Offers are ordered by CurrentUses descending
- [ ] Offer ID 7 (200 uses) appears first
- [ ] Offer ID 12 (156 uses) appears second
- [ ] Offer ID 1 (150 uses) appears third

### HigherEvaluation Filter (filterType: 4)
- [ ] Offers are ordered by Rating descending
- [ ] Offer ID 5 (4.9 rating) appears first
- [ ] Offer ID 1 (4.8 rating) appears second
- [ ] Offer ID 11 (4.7 rating) appears third

### LastInserted Filter (filterType: 2)
- [ ] Offers are ordered by CreatedAt descending
- [ ] Newest offers appear first

### NearestLocation Filter (filterType: 1)
- [ ] Offers are ordered by distance from user location
- [ ] distanceInKm field is calculated correctly
- [ ] Closest offers appear first

### Invalid Coordinates (0,0)
- [ ] distanceInKm is null when userLatitude and userLongitude are both 0
- [ ] No distance calculation is performed for (0,0) coordinates
- [ ] Filtering still works correctly (e.g., MaxUsed, HigherEvaluation)
- [ ] NearestLocation filter doesn't apply distance sorting for (0,0) coordinates

### Common Validations
- [ ] Response structure matches GetPaginatedOfferResponse
- [ ] CategoryId filtering works correctly
- [ ] IsSaved status is returned correctly
- [ ] Pagination works correctly
- [ ] Error handling works for invalid requests

## 🐛 Troubleshooting

### If MaxUsed filter doesn't work:
1. Check that CurrentUses field was updated in database
2. Run `VerifyTestData.sql` to confirm data
3. Check API logs for SQL errors

### If HigherEvaluation filter doesn't work:
1. Check that Rating field was updated in database
2. Verify Rating values are between 0-5
3. Check for null Rating values

### If distance calculation is wrong:
1. Verify OfferLocation coordinates are set
2. Check user coordinates are valid
3. Ensure DistanceCalculator is working

## 📝 Notes
- Test data covers offers with IDs 1-15
- CurrentUses values range from 8 to 200
- Rating values range from 1.8 to 4.9
- All test data includes proper CategoryId assignments
- Distance calculations use Haversine formula
