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
    public class GuideRepository : IGuideRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public GuideRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Guide> GetAllGuides()
        {
            return _dbContext.Set<Guide>().ToList();
        }

        public Guide GetGuideById(int id)
        {
            return _dbContext.Set<Guide>().Find(id);
        }

        public void AddGuide(Guide guides)
        {
            _dbContext.Set<Guide>().Add(guides);
            _dbContext.SaveChanges();
        }

        public void UpdateGuide(Guide guides)
        {
            _dbContext.Entry(guides).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteGuide(int id)
        {
            var guides = _dbContext.Set<Guide>().Find(id);
            if (guides != null)
            {
                _dbContext.Set<Guide>().Remove(guides);
                _dbContext.SaveChanges();
            }
        }
    }
}
