using ids.core.Interfaces;
using ids.core.Models;
using ids.core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ActivityClubPortalContext _dbContext;

        public UserRepository(ActivityClubPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Set<User>().ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }


        public void AddUser(User user)
        {
            _dbContext.Set<User>().Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Set<User>().Find(id);
            if (user != null)
            {
                _dbContext.Set<User>().Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public void AddRole(int userId, int RoleId)
        {
            var userRole = new UsersRole
            {
                UsersId = userId,
                //Users = _dbContext.Set<User>().Find(vm.UserId),
                RolesId = RoleId,
                // Roles = vm.Role
            };

            _dbContext.Set<UsersRole>().Add(userRole);
            _dbContext.SaveChanges();
        }
    }
}
