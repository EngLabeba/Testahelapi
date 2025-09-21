using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeId { get; set; } = string.Empty; // "123455" from the design
        public string Name { get; set; } = string.Empty; // "محمد عبدالله" / "Mohammed Abdullah"
        public string NameEnglish { get; set; } = string.Empty; // English name
        public string Position { get; set; } = string.Empty; // "مدير وحدة التصوير" / "Director of the photography unit"
        public string PositionEnglish { get; set; } = string.Empty; // English position
        public int Rank { get; set; } // "المرتبة : 8" / "Rank : 8"
        public string Department { get; set; } = string.Empty; // "إدارة الإعلام والاتصال المؤسسي"
        public string DepartmentEnglish { get; set; } = string.Empty; // English department
        
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        // Navigation properties
        public virtual ICollection<OfferShare> SharedOffers { get; set; } = new List<OfferShare>();
        public virtual ICollection<SavedOffer> SavedOffers { get; set; } = new List<SavedOffer>();
        public virtual ICollection<OfferUsage> OfferUsages { get; set; } = new List<OfferUsage>();
    }
}
