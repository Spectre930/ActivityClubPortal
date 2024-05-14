using ids.core.Interfaces;
using ids.core.Models;
using ids.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public void AddRole(Role role)
        {
            if (ValidateProduct(role))
            {
                _roleRepository.AddRole(role);
            }
            else
            {
                throw new ArgumentException("Invalid role data");
            }
        }

        public void UpdateRole(Role role)
        {
            if (ValidateProduct(role))
            {
                _roleRepository.UpdateRole(role);
            }
            else
            {
                throw new ArgumentException("Invalid role data");
            }
        }

        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }
        private bool ValidateProduct(Role role)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(role.RoleName))
            {
                return false;
            }

            return true;
        }
    }
}
