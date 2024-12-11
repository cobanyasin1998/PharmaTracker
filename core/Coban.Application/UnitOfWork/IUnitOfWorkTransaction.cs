namespace Coban.Application.UnitOfWork;

public interface  IUnitOfWorkTransaction
{  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();

}
