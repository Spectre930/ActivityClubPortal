namespace ActivityClubPortal.API.Resources.Viewmodels
{
    public class HomeVm
    {
        public IEnumerable<EventResource>? Events { get; set; }
        public IEnumerable<GuideResource>? Guides { get; set; }
        public IEnumerable<LookupResource>? Lookups { get; set; }
    }
}
