using ActivityClubPortal.API.Resources;
using ids.core.ViewModels;



namespace ActivityClubPortal.UI.Repository.IRepository;

public interface IUsersHttp : IRepositoryHttp<UserResource>
{
    Task CreateUser(UserResource vm);
    Task<bool> Login(LoginVm vm);
    Task<UserResource> GetUserByEmail(string email);
    Task AddRole(int userId, int RoleId);
}

