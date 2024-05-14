using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ActivityClubPortal.UI.Repository;

public class UsersHttp : RepositoryHttp<UserResource>, IUsersHttp
{
    private readonly HttpClient _client;
    //private readonly IHttpContextAccessor _contextAccessor;
    public UsersHttp(HttpClient client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
    {
        _client = client;
        //_contextAccessor = contextAccessor;
    }

    public async Task CreateUser(UserResource vm)
    {
        AuthorizeHeader();
        var response = await _client.PostAsJsonAsync("User/create", vm);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

    }

    public async Task<bool> Login(LoginVm vm)
    {
        var response = await _client.PostAsJsonAsync("User/login", vm);

        if (response.IsSuccessStatusCode)
        {
            await StoreToken(response);
            return true;

        }
        else
        {
            return false;
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

    }

    public async Task<UserResource> GetUserByEmail(string email)
    {
        AuthorizeHeader();
        var response = await _client.GetAsync($"User/GetUserByEmail?email={email}");
        if (response.IsSuccessStatusCode)
        {
            var responseStream = response.Content.ReadAsStringAsync().Result;
            var ResObject = JsonConvert.DeserializeObject<UserResource>(responseStream);
            return ResObject;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);

    }

    public async Task AddRole(int userId, int RoleId)
    {
        var response = await _client.PostAsync($"User/{userId}/addRole?RoleId={RoleId}", null);

        if (response.IsSuccessStatusCode)
        {
            return;
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }
}
