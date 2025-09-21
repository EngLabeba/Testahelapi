# Get Offer Sharing Methods API Test Guide

## 🎯 Overview
This guide provides comprehensive testing instructions for the `get-offer-sharing-methods` API endpoint.

## 📋 Prerequisites
1. SQL Server running with OffersDb database
2. API running and accessible
3. Test data setup completed

## 🚀 Quick Setup

### Step 1: Setup Test Data
```sql
-- Run the setup script
DatabaseTest/SetupSharingMethodsTestData.sql
```

### Step 2: Verify Data
The script will show you which offers have which sharing methods.

## 🧪 Test Scenarios

### **1. Basic Functionality Test**

#### **Test Case 1.1: Offer with Multiple Sharing Methods**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": 1
}
```

**Expected Result:**
- ✅ Returns 4 sharing methods
- ✅ Includes: مشاركة مع التابعين, مشاركة مع منسوبي الأمانة, مشاركة على وسائل التواصل, رابط مباشر
- ✅ All sharing methods are active

#### **Test Case 1.2: Offer with Limited Sharing Methods**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": 2
}
```

**Expected Result:**
- ✅ Returns 2 sharing methods
- ✅ Includes: مشاركة مع التابعين, مشاركة على وسائل التواصل

#### **Test Case 1.3: Offer with Single Sharing Method**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": 6
}
```

**Expected Result:**
- ✅ Returns 1 sharing method
- ✅ Includes: مشاركة مع منسوبي الأمانة

#### **Test Case 1.4: Offer that Cannot be Shared**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": 4
}
```

**Expected Result:**
- ✅ Returns 1 sharing method
- ✅ Includes: لا يمكن المشاركة

### **2. Error Handling Test**

#### **Test Case 2.1: Non-existent Offer**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": 999
}
```

**Expected Result:**
- ❌ Returns error: "Offer not found or inactive"
- ❌ Error code: "offer_not_found"

#### **Test Case 2.2: Invalid Offer ID**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": -1
}
```

**Expected Result:**
- ❌ Returns validation error
- ❌ Error message: "OfferId must be greater than 0"

#### **Test Case 2.3: Inactive Offer**
```json
POST /api/Offers/get-offer-sharing-methods
{
  "offerId": [ID_OF_INACTIVE_OFFER]
}
```

**Expected Result:**
- ❌ Returns error: "Offer not found or inactive"

### **3. Data Integrity Test**

#### **Test Case 3.1: Verify Response Structure**
For any valid offer ID, verify:
- ✅ `offerId` matches request
- ✅ `offerTitle` is populated
- ✅ `sharingMethods` is an array
- ✅ `totalCount` matches array length
- ✅ Each sharing method has all required fields

#### **Test Case 3.2: Verify Sharing Method Fields**
For each sharing method in response:
- ✅ `id` is a positive integer
- ✅ `name` is not empty (Arabic)
- ✅ `nameEnglish` is not empty
- ✅ `iconUrl` contains icon (emoji or URL)
- ✅ `description` is populated
- ✅ `descriptionEnglish` is populated
- ✅ `isActive` is true

## 📊 Test Data Summary

| Offer ID | Sharing Methods Count | Sharing Methods |
|----------|----------------------|-----------------|
| 1 | 4 | Dependents, Municipality, Social Media, Direct Link |
| 2 | 2 | Dependents, Social Media |
| 3 | 2 | Social Media, Direct Link |
| 4 | 1 | Cannot be Shared |
| 5 | 4 | Dependents, Municipality, Social Media, Direct Link |
| 6 | 1 | Municipality Only |
| 7 | 2 | Dependents, Social Media |
| 8 | 1 | Direct Link Only |
| 9 | 4 | Dependents, Municipality, Social Media, Direct Link |
| 10 | 1 | Cannot be Shared |

## 🔍 Verification Checklist

### **Response Structure Validation:**
- [ ] Response contains `offerId`
- [ ] Response contains `offerTitle`
- [ ] Response contains `sharingMethods` array
- [ ] Response contains `totalCount`
- [ ] `totalCount` matches `sharingMethods.length`

### **Sharing Method Validation:**
- [ ] Each sharing method has `id`
- [ ] Each sharing method has `name` (Arabic)
- [ ] Each sharing method has `nameEnglish`
- [ ] Each sharing method has `iconUrl`
- [ ] Each sharing method has `description`
- [ ] Each sharing method has `descriptionEnglish`
- [ ] Each sharing method has `isActive: true`

### **Business Logic Validation:**
- [ ] Only active offers return sharing methods
- [ ] Only active sharing methods are returned
- [ ] Junction table `OfferOfferSharingMethod` is properly queried
- [ ] Many-to-many relationship works correctly

## 🐛 Troubleshooting

### **If API returns empty sharing methods:**
1. Check if offer exists in database
2. Verify offer is active (`IsActive = 1`)
3. Check if offer has relationships in `OfferOfferSharingMethod` table
4. Verify sharing methods are active

### **If API returns error:**
1. Check offer ID is valid (positive integer)
2. Verify offer exists in database
3. Check if offer is active
4. Review API logs for detailed error messages

### **If sharing methods are missing:**
1. Run the setup script to create test relationships
2. Check `OfferOfferSharingMethod` junction table
3. Verify sharing methods exist in `OfferSharingMethods` table

## 📝 Sample Test Commands

### **Using curl:**
```bash
# Test offer with multiple sharing methods
curl -X POST "https://localhost:7000/api/Offers/get-offer-sharing-methods" \
  -H "Content-Type: application/json" \
  -d '{"offerId": 1}'

# Test offer with limited sharing methods
curl -X POST "https://localhost:7000/api/Offers/get-offer-sharing-methods" \
  -H "Content-Type: application/json" \
  -d '{"offerId": 2}'

# Test error case
curl -X POST "https://localhost:7000/api/Offers/get-offer-sharing-methods" \
  -H "Content-Type: application/json" \
  -d '{"offerId": 999}'
```

### **Using Postman:**
1. Set method to POST
2. Set URL to `/api/Offers/get-offer-sharing-methods`
3. Set Content-Type to `application/json`
4. Set body to `{"offerId": 1}`
5. Send request

## ✅ Success Criteria

The API is working correctly if:
- ✅ Valid offers return their associated sharing methods
- ✅ Invalid offers return appropriate error messages
- ✅ Response structure matches the expected format
- ✅ All sharing method fields are populated correctly
- ✅ Junction table relationships are properly queried
- ✅ Only active offers and sharing methods are returned

## 🎯 Expected Use Cases

This API will be used for:
- **Mobile Apps**: Display sharing options for offers
- **Web Applications**: Show available sharing methods
- **Social Features**: Enable users to share offers
- **Analytics**: Track which sharing methods are available
- **UI Components**: Render sharing buttons/icons
