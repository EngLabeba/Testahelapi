namespace Application.Features.DependentsFeatures.GetAll
{
    public class GetAllDependentsResponse
    {
        public List<DependentItem> Dependents { get; set; } = new List<DependentItem>();
        public int TotalCount { get; set; }
    }

    public class DependentItem
    {
        public int Id { get; set; }
        public string Relationship { get; set; } = string.Empty;
        public string RelationshipEnglish { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
