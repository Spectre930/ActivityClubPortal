using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.User.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public UserHomeController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _unitOfWorkHttp.Events.GetEvents();
            if (_unitOfWorkHttp.IsLogged())
            {
                var eventIds = await _unitOfWorkHttp.Members.GetEvents();
                var Ids = eventIds.Select(x => x.Id).ToList();
                events = events.Where(x => !Ids.Contains(x.Event.Id)).ToList();
            }
            var guides = await _unitOfWorkHttp.Guides.GetAllAsync("Guide");
            var lookups = await _unitOfWorkHttp.Lookups.GetAllAsync("Lookup");

            var ResObj = new HomeVm
            {
                Events = events.Select(x => x.Event),
                Guides = guides,
                Lookups = lookups.Take(4).ToList()
            };

            return View(ResObj);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (await _unitOfWorkHttp.Users.Login(vm))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }




            try
            {
                await _unitOfWorkHttp.Members.MemberLogin(vm);
                ViewBag.Status = "LoggedIn";
                return RedirectToAction("Index", "UserHome", new { area = "User" });
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        public IActionResult Logout()
        {
            try
            {
                _unitOfWorkHttp.Logout();
                return RedirectToAction("Index", "UserHome", new { area = "User" });
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }


        }

        public IActionResult Forbidden()
        {
            return View("Login", "UserHome");
        }

    }
}
