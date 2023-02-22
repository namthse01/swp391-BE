using Application.Interfaces;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositoties;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositoties == null)
            {
                _repositoties = new Dictionary<string, object>();
            }
            var type = typeof(TEntity).Name;
            if (!_repositoties.ContainsKey(type))
            {
                var respositoryInstance = new GenericRepository<TEntity>(_context);
                _repositoties.Add(type, respositoryInstance);
            }
            return (IGenericRepository<TEntity>)_repositoties[type];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}