using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services.Interfaces
{
    public interface IUserRoleService
    {
        IEnumerable<UsersRole> GetAllUserRoles();
        void AddUserRole(UsersRole userRole);
        void UpdateUserRole(UsersRole userRole);
        void DeleteUserRole(int id);

    }
}
