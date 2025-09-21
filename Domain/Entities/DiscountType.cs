using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DiscountType : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // "Percentage", "Special Offer", "Fixed Amount"
        
        public string? Description { get; set; } // Description of the discount type
        
        public string? Icon { get; set; } // Icon for UI display
        public DiscountType() { }
        
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
