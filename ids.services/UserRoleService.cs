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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public IEnumerable<UsersRole> GetAllUserRoles()
        {
            return _userRoleRepository.GetAllUserRoles();
        }

        public void AddUserRole(UsersRole userRole)
        {
            if (ValidateProduct(userRole))
            {
                _userRoleRepository.AddUserRole(userRole);
            }
            else
            {
                throw new ArgumentException("Invalid UserRole data");
            }
        }

        public void UpdateUserRole(UsersRole userRole)
        {
            if (ValidateProduct(userRole))
            {
                _userRoleRepository.UpdateUserRole(userRole);
            }
            else
            {
                throw new ArgumentException("Invalid UserRole data");
            }
        }

        public void DeleteUserRole(int id)
        {
            _userRoleRepository.DeleteUserRole(id);
        }
        private bool ValidateProduct(UsersRole userRole)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(userRole.Users.FullName))
            {
                return false;
            }

            return true;
        }
    }
}
