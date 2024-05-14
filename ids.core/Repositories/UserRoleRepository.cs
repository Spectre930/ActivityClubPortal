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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public UserRoleRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UsersRole> GetAllUserRoles()
        {
            return _dbContext.Set<UsersRole>().ToList();
        }

        public void AddUserRole(UsersRole userRole)
        {
            _dbContext.Set<UsersRole>().Add(userRole);
            _dbContext.SaveChanges();
        }

        public void UpdateUserRole(UsersRole userRole)
        {
            _dbContext.Entry(userRole).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUserRole(int id)
        {
            var userRole = _dbContext.Set<UsersRole>().Find(id);
            if (userRole != null)
            {
                _dbContext.Set<UsersRole>().Remove(userRole);
                _dbContext.SaveChanges();
            }
        }
    }
}
