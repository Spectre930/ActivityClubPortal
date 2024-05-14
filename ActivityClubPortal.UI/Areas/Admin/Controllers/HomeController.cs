using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWorkHttp _unitOfWorkHttp;

    public HomeController(IUnitOfWorkHttp unitOfWorkHttp)
    {
        _unitOfWorkHttp = unitOfWorkHttp;
    }
    public IActionResult Index()
    {
        return View();
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
        try
        {
            await _unitOfWorkHttp.Users.Login(vm);
            return RedirectToAction("Index", "Home", new { area = "Admin" });
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

}