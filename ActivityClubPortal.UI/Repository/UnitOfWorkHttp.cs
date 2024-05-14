using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;

namespace ActivityClubPortal.UI.Repository;

public class UnitOfWorkHttp : IUnitOfWorkHttp, IDisposable
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _contextAccessor;
    public IMembersHttp Members { get; private set; }
    public IEventsHttp Events { get; private set; }
    public IGuidesHttp Guides { get; private set; }
    public IUsersHttp Users { get; private set; }
    public IRepositoryHttp<RoleResource> Roles { get; private set; }
    public IRepositoryHttp<LookupResource> Lookups { get; private set; }

    public UnitOfWorkHttp(HttpClient client, IHttpContextAccessor contextAccessor)
    {
        _client = client;
        _contextAccessor = contextAccessor;
        Roles = new RepositoryHttp<RoleResource>(_client, _contextAccessor);
        Events = new EventsHttp(client, _contextAccessor);
        Guides = new GuidesHttp(_client, _contextAccessor);
        Lookups = new RepositoryHttp<LookupResource>(_client, _contextAccessor);
        Members = new MembersHttp(_client, _contextAccessor);
        Users = new UsersHttp(_client, _contextAccessor);
    }

    public bool IsLogged()
    {
        var session = _contextAccessor.HttpContext.Session.GetString("Token");
        if (session == null)
        {
            return false;
        }
        return true;
    }

    public void Logout()
    {
        if (_contextAccessor.HttpContext != null)
        {
            _contextAccessor.HttpContext.Session.Remove("Token");
            _client.DefaultRequestHeaders.Authorization = null;
            return;
        }
        throw new Exception("There was a problem Logging out");
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}
