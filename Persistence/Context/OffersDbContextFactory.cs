using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context
{
    public class OffersDbContextFactory : IDesignTimeDbContextFactory<OffersDbContext>
    {
        public OffersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OffersDbContext>();
            
            // Use a generic connection string for design-time migrations
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=OffersDb;Integrated Security=True;TrustServerCertificate=True");

            return new OffersDbContext(optionsBuilder.Options);
        }
    }
}
