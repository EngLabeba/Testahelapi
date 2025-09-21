using Domain.Common;
using System;

namespace Domain.Entities
{
    public class OfferUsage : BaseEntity
    {
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; } = null!;
        
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        
        public int DependentId { get; set; }
        public virtual Dependent Dependent { get; set; } = null!;
        
        public DateTime UsedAt { get; set; } = DateTime.UtcNow;
        
        public string? Notes { get; set; } // Optional notes about the usage
        
        public string? LocationUsed { get; set; } // Where the offer was used
        
        public decimal? AmountSaved { get; set; } // How much was saved using this offer
        
        public bool IsVerified { get; set; } = false; // Whether the usage was verified
        
        public string? VerifiedBy { get; set; } // Who verified the usage
        
        public DateTime? VerifiedAt { get; set; } // When it was verified
    }
}
