using Domain.Common;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    void Dispose();
    void Dispose(bool disposing);
    void Commit();
    Task CommitAsync();
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
}