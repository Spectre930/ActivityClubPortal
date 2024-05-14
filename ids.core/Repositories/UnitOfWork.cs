using ids.core.Interfaces;
using ids.core.Models;


namespace ids.core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ActivityClubPortalContext _context;
        private EventRepository _eventRepository;
        public UnitOfWork(ActivityClubPortalContext context)
        {
            this._context = context;
        }

        public IEventRepository Events => _eventRepository = _eventRepository ?? new EventRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
