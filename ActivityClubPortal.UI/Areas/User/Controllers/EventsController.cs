using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.User.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public EventsController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }
        public async Task<IActionResult> Event(int Id)
        {
            var resObj = await _unitOfWorkHttp.Events.GetEvent(Id);
            return View(resObj);
        }
    }
}
