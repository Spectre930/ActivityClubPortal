using ids.core.Models;
using ids.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddRole(int userId, int RoleId);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
