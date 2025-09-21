using Application.Common.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICategoryRepository : IBaseRepository<OfferCategory>
    {
        Task<IEnumerable<OfferCategory>> GetAllCategoriesAsync();
        Task<OfferCategory?> GetCategoryByIdAsync(int id);
    }
}
