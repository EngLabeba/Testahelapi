# Mobile App API Mapping Guide

## 📱 Mobile App Interface Analysis

Based on the mobile app screenshot showing "العروض المحفوظة" (Saved Offers), here's how our API data maps to the mobile interface:

## 🎯 API Data Mapping to Mobile UI

### **Mobile App Elements → API Response Fields**

| Mobile UI Element | API Field | Description |
|------------------|-----------|-------------|
| **Offer Name** | `OfferTitle` or `Name` | "المسافر", "بنك الجزيرة", "بيت الشاورما", "ولنس كتشن" |
| **Discount Value** | `DiscountValue` | "10%", "أسعار خاصة", "20%", "5%" |
| **Description** | `OfferDescription` | "هذا النص هو مثال لنص يمكن أن يستبدل" |
| **Distance** | `DistanceInKm` | "(2.55)" - calculated from user location |
| **Directions Button** | `DirectionsUrl` | "الإتجاهات" button functionality |
| **Bookmark Icon** | `IsSaved` | Gold bookmark indicating saved status |
| **Organization Logo** | `ImageUrl` | Company/brand logos on the right side |

## 🔗 API Endpoints for Mobile App

### **1. Get Saved Offers (Main Screen)**
```json
POST /api/Offers/get-saved-offers
{
  "userId": "user123"
}
```

**Response Fields Used by Mobile App:**
```json
{
  "savedOffers": [
    {
      "offerId": 1,
      "offerTitle": "المسافر",           // ← Mobile: Offer Name
      "offerDescription": "هذا النص هو مثال...", // ← Mobile: Description
      "discountValue": "10%",            // ← Mobile: Discount
      "organizationName": "المسافر",      // ← Mobile: Organization
      "imageUrl": "https://...",         // ← Mobile: Logo
      "savedAt": "2024-01-15T10:30:00Z", // ← Mobile: Order by newest
      "isUsed": false                    // ← Mobile: Status
    }
  ],
  "totalCount": 4
}
```

### **2. Get Offer Details (When User Taps Offer)**
```json
POST /api/Offers/get-offer-details
{
  "offerId": 1
}
```

**Response Fields Used by Mobile App:**
```json
{
  "id": 1,
  "title": "المسافر",                    // ← Mobile: Offer Name
  "description": "هذا النص هو مثال...",   // ← Mobile: Full Description
  "discountValue": "10%",               // ← Mobile: Discount
  "validFrom": "2024-01-01T00:00:00Z",  // ← Mobile: Validity
  "validUntil": "2024-12-31T23:59:59Z",
  "isCurrentlyValid": true,             // ← Mobile: Active Status
  "directionsUrl": "https://maps...",   // ← Mobile: Directions Button
  "imageUrl": "https://...",            // ← Mobile: Logo
  "locations": [                        // ← Mobile: Distance Calculation
    {
      "latitude": 24.7136,
      "longitude": 46.6753,
      "distanceInKm": 2.55              // ← Mobile: "(2.55)"
    }
  ],
  "termsAndConditions": "..."           // ← Mobile: Terms (if shown)
}
```

### **3. Save Offer (Bookmark Functionality)**
```json
POST /api/Offers/save-offer
{
  "offerId": 1,
  "userId": "user123",
  "notes": "Great offer!"
}
```

### **4. Get Paginated Offers (Browse All Offers)**
```json
POST /api/Offers/get-paginated-offers
{
  "paginationInput": { "currentPage": 1, "takenRows": 10 },
  "userId": "user123",
  "userLatitude": 24.7136,
  "userLongitude": 46.6753
}
```

## 📊 Mobile App Data Requirements

### **For Saved Offers Screen:**
✅ **All Required Fields Available:**
- ✅ Offer Name (`offerTitle`)
- ✅ Discount Value (`discountValue`)
- ✅ Description (`offerDescription`)
- ✅ Distance (`distanceInKm` - from paginated offers API)
- ✅ Directions URL (`directionsUrl`)
- ✅ Saved Status (`isSaved` = true for saved offers)
- ✅ Organization Logo (`imageUrl`)
- ✅ Validity Status (`isCurrentlyValid`)

### **For Offer Details Screen:**
✅ **All Required Fields Available:**
- ✅ Full Offer Information
- ✅ Multiple Locations with Distances
- ✅ Terms and Conditions
- ✅ Validity Period
- ✅ Rating Information
- ✅ Usage Statistics

## 🎨 Mobile App Implementation Notes

### **Distance Display:**
- Mobile shows "(2.55)" format
- Our API provides `distanceInKm` as decimal
- Mobile app should format: `"(" + distanceInKm.ToString("F2") + ")"`

### **Discount Display:**
- Mobile shows various formats: "10%", "أسعار خاصة", "20%", "5%"
- Our API provides `discountValue` as string (flexible format)
- Supports both percentage and text-based discounts

### **Directions Button:**
- Mobile shows "الإتجاهات" (Directions) button
- Our API provides `directionsUrl` for direct navigation
- Button should open the URL in maps app

### **Bookmark Icon:**
- Mobile shows gold bookmark for saved offers
- Our API provides `isSaved` boolean
- For saved offers screen, all offers have `isSaved = true`

### **Ordering:**
- Mobile shows newest saved offers first
- Our API orders by `savedAt` descending (newest first)
- Perfect match for mobile app requirements

## 🔧 Mobile App Integration Checklist

### **Saved Offers Screen:**
- [ ] Call `get-saved-offers` API with user ID
- [ ] Display offers in cards with all required fields
- [ ] Format distance as "(X.XX)" 
- [ ] Show gold bookmark icon (all are saved)
- [ ] Order by newest first (API already does this)
- [ ] Handle directions button with `directionsUrl`

### **Offer Details Screen:**
- [ ] Call `get-offer-details` API with offer ID
- [ ] Display comprehensive offer information
- [ ] Show multiple locations if available
- [ ] Display terms and conditions
- [ ] Show validity period and status

### **Save/Unsave Functionality:**
- [ ] Call `save-offer` API to save offers
- [ ] Update UI to show bookmark status
- [ ] Handle duplicate save prevention
- [ ] Show success/error messages

## ✅ Conclusion

**All mobile app requirements are fully supported by our APIs!**

The mobile app can be implemented using:
1. **`get-saved-offers`** - for the main saved offers screen
2. **`get-offer-details`** - for detailed offer views
3. **`save-offer`** - for bookmark functionality
4. **`get-paginated-offers`** - for browsing all offers with distance calculation

The API responses provide all necessary data fields that match the mobile app interface perfectly.
