using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using ids.core.ViewModels;

namespace ActivityClubPortal.UI.Repository.IRepository
{
    public interface IEventsHttp : IRepositoryHttp<EventResource>
    {
        Task<IEnumerable<GuideResource>> GetEventGuides(int EventId);
        Task<IEnumerable<EventsVm>> GetEvents();
        Task<EventsVm> GetEvent(int EventId);
        Task DropGuide(int EventId, int GuideId);
        Task AddGuide(int EventId, int GuideId);
        Task SetLookup(int EventId, int LoopupId);
        Task<IEnumerable<MemberResource>> GetMembers(int EventId);
    }
}
