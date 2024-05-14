using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ActivityClubPortal.API.Resources.Viewmodels
{
    public class EventsPostVm
    {
        public EventResource Event { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LookupList { get; set; }
    }
}
