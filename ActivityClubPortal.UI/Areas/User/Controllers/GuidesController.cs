using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.User.Controllers
{
    public class GuidesController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public GuidesController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }
        public async Task<IActionResult> Guide(int Id)
        {
            var guide = await _unitOfWorkHttp.Guides.GetAsync("Guide", Id);
            var events = await _unitOfWorkHttp.Guides.GetEvents(Id);
            var resObj = new GuidesVm
            {
                guide = guide,
                events = events
            };
            return View(resObj);
        }
    }
}
