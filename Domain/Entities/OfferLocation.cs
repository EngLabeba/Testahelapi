using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class OfferLocation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        
        public string? State { get; set; }
        
        public string? PostalCode { get; set; }
        
        public string? Country { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
