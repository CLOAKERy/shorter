using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ILinkRepository _linkRepository; 
        private readonly ShorterContext _db;

        public UnitOfWork(ShorterContext db)
        {
            _db = db;
        }
        public ILinkRepository Links 
        {
            get
            {
                if (_linkRepository == null)
                    _linkRepository = new LinkRepository(_db);
                return _linkRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
