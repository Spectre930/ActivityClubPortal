using ids.core.Interfaces;
using ids.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public LookupRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lookup> GetAllLookups()
        {
            return _dbContext.Set<Lookup>().ToList();
        }

        public Lookup GetLookupById(int id)
        {
            return _dbContext.Set<Lookup>().Find(id);
        }

        public void AddLookup(Lookup lookup)
        {
            _dbContext.Set<Lookup>().Add(lookup);
            _dbContext.SaveChanges();
        }

        public void UpdateLookup(Lookup lookup)
        {
            _dbContext.Entry(lookup).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteLookup(int id)
        {
            var lookup = _dbContext.Set<Lookup>().Find(id);
            if (lookup != null)
            {
                _dbContext.Set<Lookup>().Remove(lookup);
                _dbContext.SaveChanges();
            }
        }
    }
}
