using Domain.Common;
using System;

namespace Domain.Entities
{
    public class OfferShare : BaseEntity
    {
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; } = null!;
        
        public string SharedByUserId { get; set; } = string.Empty; // Employee who shared the offer
        public string? SharedWithUserId { get; set; } // Dependent or other user who received the offer
        
        public int? DependentId { get; set; } // If shared with a specific dependent
        public virtual Dependent? Dependent { get; set; }
        
        public string ShareToken { get; set; } = string.Empty; // Unique token for QR code
        public string QrCodeIdentifier { get; set; } = string.Empty; // Unique identifier for QR code (shorter, more user-friendly)
        public string QrCodeData { get; set; } = string.Empty; // The actual data to be encoded in QR code
        
        public DateTime SharedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; } // When the share expires
        
        public bool IsScanned { get; set; } = false; // Whether QR code has been scanned
        public DateTime? ScannedAt { get; set; } // When it was scanned
        public string? ScannedByUserId { get; set; } // Who scanned it
        
        public bool IsUsed { get; set; } = false; // Whether the offer has been used
        public DateTime? UsedAt { get; set; } // When the offer was used
        
        public string? Notes { get; set; } // Additional notes from the sharer
        public string? UsageNotes { get; set; } // Notes from when it was used
    }
}
