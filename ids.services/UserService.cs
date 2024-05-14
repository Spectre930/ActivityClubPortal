using ids.core.Interfaces;
using ids.core.Models;
using ids.core.ViewModels;
using ids.services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ids.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void AddUser(User user)
        {
            if (ValidateProduct(user))
            {
                _userRepository.AddUser(user);
            }
            else
            {
                throw new ArgumentException("Invalid user data");
            }
        }

        public string LoginUser(LoginVm vm)
        {

            var user = _userRepository.GetUserByEmail(vm.email);
            if (user == null || user.Password != vm.password)
            {
                throw new Exception("incorrect email or password!");
            }


            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public void UpdateUser(User user)
        {
            // Validate user data
            if (!ValidateProduct(user))
            {
                throw new ArgumentException("Invalid user data");
            }

            var existingUser = _userRepository.GetUserById(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found");
            }

            // Check for email uniqueness
            if (user.Email != existingUser.Email && _userRepository.GetUserByEmail(user.Email) != null)
            {
                throw new ArgumentException("Email already exists");
            }

            // Check for password change
            if (user.Password != existingUser.Password)
            {
                existingUser.Password = user.Password; // Assuming you're storing the plain text password; otherwise, hash it here
            }

            // Update other user properties
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;

            _userRepository.UpdateUser(existingUser);
        }


        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
        private bool ValidateProduct(User user)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                return false;
            }

            return true;
        }

        public void AddRole(int userId, int RoleId)
        {
            _userRepository.AddRole(userId, RoleId);
        }
    }
}
