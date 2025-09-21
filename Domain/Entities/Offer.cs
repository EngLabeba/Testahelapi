using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Offer : BaseEntity
    {
        
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public int DiscountTypeId { get; set; }
        public virtual DiscountType DiscountType { get; set; } = null!;
        
        public string DiscountValue { get; set; } = string.Empty; // Can be "20" for percentage or "Special Offer" for text
       
        
        public DateTime ValidFrom { get; set; } // When the offer becomes valid
        
        public DateTime ValidUntil { get; set; } // When the offer expires
      
       
        public int CategoryId { get; set; }
        public virtual OfferCategory Category { get; set; } = null!;
        
        public virtual ICollection<OfferLocation> Locations { get; set; } = new List<OfferLocation>();
        
        public virtual ICollection<OfferPlatform> Platforms { get; set; } = new List<OfferPlatform>();
        
        public virtual ICollection<OfferSharingMethod> SharingMethods { get; set; } = new List<OfferSharingMethod>();
        
        public string? OrganizationName { get; set; } // "أمانة منطقة الرياض" / "Riyadh Region Municipality"
        
        public string? OrganizationNameEnglish { get; set; }
        
        public string? DirectionsUrl { get; set; } // URL for "الذهاب إلى الإتجاهات" (Go to Directions)
       
        //For rating Filter 
        public decimal? Rating { get; set; } // Offer rating (0-5)
        
        public int RatingCount { get; set; } = 0; // Number of ratings
        
        public virtual ICollection<SavedOffer> SavedOffers { get; set; } = new List<SavedOffer>();
        
        public int? EmployeeId { get; set; } // Which employee can use the offer (one offer for one employee)
        public virtual Employee? Employee { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public string? TermsAndConditions { get; set; } 
       
        //for filter الأكثر استخداما
        public int CurrentUses { get; set; } = 0;

         // Terms and conditions for the offer
        // public int? MaxUses { get; set; }
        // public string? CouponCode { get; set; } // Optional coupon code

        // public decimal? MinimumPurchase { get; set; } // Minimum purchase amount to use offer

        // public bool IsStackable { get; set; } = false; // Can be combined with other offers


    }
}
