using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SavedOffer : BaseEntity
    {
        
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; } = null!;
        
        public string? UserId { get; set; } // For external users or general sharing
        
        public DateTime SavedAt { get; set; } = DateTime.UtcNow;
        
        public string? Notes { get; set; }
        
        public bool IsUsed { get; set; } = false; // Whether the offer has been used
        
        public DateTime? UsedAt { get; set; } // When the offer was used
    }
}
