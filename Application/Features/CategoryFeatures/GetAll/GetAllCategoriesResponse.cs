using Application.Common.Models;
using Domain.Entities;

namespace Application.Features.CategoryFeatures.GetAll
{
    public class GetAllCategoriesResponse : GeneralResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}
