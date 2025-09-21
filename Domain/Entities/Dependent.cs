using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Dependent:BaseEntity
    {
        
        public string Relationship { get; set; } = string.Empty; // "أبنة" (Daughter), "زوجة" (Wife), etc.
        
        public string RelationshipEnglish { get; set; } = string.Empty; // English relationship
 
        
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public virtual ICollection<OfferUsage> OfferUsages { get; set; } = new List<OfferUsage>();
    }
}
