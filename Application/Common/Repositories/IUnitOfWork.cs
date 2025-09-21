namespace Application.Common.Repositories
{
    public interface IUnitOfWork
    {

        Task Save(CancellationToken cancellationToken);
    }
}
