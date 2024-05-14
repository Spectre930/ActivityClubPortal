using ActivityClubPortal.API.Resources;

namespace ActivityClubPortal.UI.Repository.IRepository
{
    public interface IGuidesHttp : IRepositoryHttp<GuideResource>
    {
        Task GuideAnEvent(int GuideId, int EventId);
        Task<IEnumerable<EventResource>> GetEvents(int GuideId);
    }
}
