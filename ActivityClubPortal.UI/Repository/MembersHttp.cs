using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.ViewModels;
using Newtonsoft.Json;


namespace ActivityClubPortal.UI.Repository;

public class MembersHttp : RepositoryHttp<MemberResource>, IMembersHttp
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _contextAccessor;
    public MembersHttp(HttpClient client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
    {
        _client = client;
        _contextAccessor = contextAccessor;
    }


    public async Task<bool> MemberLogin(LoginVm userLogin)
    {
        var response = await _client.PostAsJsonAsync("Member/login", userLogin);

        if (response.IsSuccessStatusCode)
        {
            await StoreToken(response);
            return true;
        }

        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public async Task CreateMember(MemberResource resource)
    {
       
        var response = await _client.PostAsJsonAsync("Member/create", resource);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }

    public async Task<IEnumerable<EventResource>> GetEvents()
    {
        AuthorizeHeader();
        var memberId = GetClaims().Id;
        var response = await _client.GetAsync($"Member/{memberId}/events");
        if (response.IsSuccessStatusCode)
        {
            var responseStream = response.Content.ReadAsStringAsync().Result;
            var ResObject = JsonConvert.DeserializeObject<IEnumerable<EventResource>>(responseStream);
            return ResObject;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public async Task<IEnumerable<EventResource>> GetEvents(int memberId)
    {
        AuthorizeHeader();
        var response = await _client.GetAsync($"Member/{memberId}/events");
        if (response.IsSuccessStatusCode)
        {
            var responseStream = response.Content.ReadAsStringAsync().Result;
            var ResObject = JsonConvert.DeserializeObject<IEnumerable<EventResource>>(responseStream);
            return ResObject;
        }
        throw new Exception(response.Content.ReadAsStringAsync().Result);
    }

    public async Task UpdateMemberAsync(MemberResource resource)
    {
        // AuthorizeHeader();

        var res = await _client.PutAsJsonAsync($"Member/update/{resource.Id}", resource);
        res.EnsureSuccessStatusCode();
    }

    public async Task<bool> JoinEvent(int EventId)
    {
        var session = _contextAccessor.HttpContext.Session.GetString("Token");
        if (session == null)
        {
            return false;
        }
        AuthorizeHeader();
        int Id = GetClaims().Id;
        var response = await _client.PostAsync($"Event/{EventId}/Join?memberId={Id}", null);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
        return true;
    }



    //public async Task<MemberResource> GetMemberByEmail(string email)
    //{
    //    AuthorizeHeader();
    //    var response = await _client.GetAsync($"Member/{id}");
    //    response.EnsureSuccessStatusCode();
    //    var responseStream = response.Content.ReadAsStringAsync().Result;

    //    var ResObject = JsonConvert.DeserializeObject<T>(responseStream);

    //    return ResObject;
    //}
}
