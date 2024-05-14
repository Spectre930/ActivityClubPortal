using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
