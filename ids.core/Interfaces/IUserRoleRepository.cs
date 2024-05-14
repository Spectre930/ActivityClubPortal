using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IUserRoleRepository
    {
        IEnumerable<UsersRole> GetAllUserRoles();
        void AddUserRole(UsersRole userRole);
        void UpdateUserRole(UsersRole userRole);
        void DeleteUserRole(int id);
    }
}
