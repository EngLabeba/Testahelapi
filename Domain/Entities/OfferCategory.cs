using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OfferCategory : BaseEntity
    {
    
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public string? Icon { get; set; }

        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
