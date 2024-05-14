using ids.core.Models;

namespace ActivityClubPortal.API.Resources.Viewmodels
{
    public class GuidesVm
    {
        public GuideResource? guide { get; set; }
        public IEnumerable<EventResource>? events { get; set; }
    }
}
