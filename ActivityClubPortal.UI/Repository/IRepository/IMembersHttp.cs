using ActivityClubPortal.API.Resources;
using ids.core.ViewModels;

namespace ActivityClubPortal.UI.Repository.IRepository
{
    public interface IMembersHttp : IRepositoryHttp<MemberResource>
    {
        Task CreateMember(MemberResource dto);
        // Task<MemberResource> GetMemberByEmail(string email);
        Task<bool> MemberLogin(LoginVm userLogin);
        Task UpdateMemberAsync(MemberResource resource);
        Task<IEnumerable<EventResource>> GetEvents();
        Task<IEnumerable<EventResource>> GetEvents(int memberId);
        Task<bool> JoinEvent(int EventId);



    }
}
