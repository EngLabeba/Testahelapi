using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsPublished { get; set; } = true;
        public DateTime? PublishedAt { get; set; }
        public string? PublishedBy { get; set; }
        public DateTime? UnpublishedAt { get; set; }
        public string? UnpublishedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
