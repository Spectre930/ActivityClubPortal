using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.User.Controllers
{
    public class LookupsController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public LookupsController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }
        public async Task<IActionResult> Index()
        {
            var resObj = await _unitOfWorkHttp.Lookups.GetAllAsync("Lookup");
            return View(resObj);
        }

    }
}
