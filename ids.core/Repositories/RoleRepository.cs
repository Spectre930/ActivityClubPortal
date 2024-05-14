using ids.core.Interfaces;
using ids.core.Models;
using Microsoft.EntityFrameworkCore;


namespace ids.core.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public RoleRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _dbContext.Set<Role>().ToList();
        }

        public Role GetRoleById(int id)
        {
            return _dbContext.Set<Role>().Find(id);
        }

        public void AddRole(Role role)
        {
            _dbContext.Set<Role>().Add(role);
            _dbContext.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _dbContext.Set<Role>().Find(id);
            if (role != null)
            {
                _dbContext.Set<Role>().Remove(role);
                _dbContext.SaveChanges();
            }
        }
    }
}
