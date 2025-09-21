using Application.Common.Repositories;
using Persistence.Context;

namespace Persistence.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OffersDbContext _context;

        public UnitOfWork(OffersDbContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
