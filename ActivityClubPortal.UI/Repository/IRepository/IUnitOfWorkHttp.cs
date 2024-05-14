using ActivityClubPortal.API.Resources;

namespace ActivityClubPortal.UI.Repository.IRepository;


public interface IUnitOfWorkHttp
{
    IMembersHttp Members { get; }
    IEventsHttp Events { get; }
    IUsersHttp Users { get; }
    IGuidesHttp Guides { get; }
    IRepositoryHttp<RoleResource> Roles { get; }
    IRepositoryHttp<LookupResource> Lookups { get; }

    bool IsLogged();
    void Logout();
}
