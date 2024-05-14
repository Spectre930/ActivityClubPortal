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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IConfiguration _configuration;

        public MemberService(IMemberRepository memberRepository, IConfiguration configuration)
        {
            _memberRepository = memberRepository;
            _configuration = configuration;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetMemberById(id);
        }

        public void AddMember(Member member)
        {
            if (ValidateProduct(member))
            {
                _memberRepository.AddMember(member);
            }
            else
            {
                throw new ArgumentException("Invalid member data");
            }
        }

        public void UpdateMember(Member member)
        {
            if (ValidateProduct(member))
            {
                _memberRepository.UpdateMember(member);
            }
            else
            {
                throw new ArgumentException("Invalid member data");
            }
        }

        public void DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);
        }
        private bool ValidateProduct(Member member)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(member.FullName))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Event> GetEvents(int MemberId)
        {
            return _memberRepository.GetEvents(MemberId);
        }

        public string LoginMember(LoginVm vm)
        {
            var member = _memberRepository.GetMemberByEmail(vm.email);
            if (member == null || vm.password != member.Password)
            {
                throw new Exception("Incorrect email or password!");
            }

            return CreateToken(member);
        }
        private string CreateToken(Member member)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
            new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role, "Member"),
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

        public Member GetMemberByEmail(string email)
        {
            return _memberRepository.GetMemberByEmail(email);
        }
    }
}
