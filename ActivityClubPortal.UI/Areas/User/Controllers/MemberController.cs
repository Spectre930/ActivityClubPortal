using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.User.Controllers
{
    public class MemberController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public MemberController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(MemberResource member)
        {
            try
            {
                await _unitOfWorkHttp.Members.CreateMember(member);
                return RedirectToAction("Index", "UserHome");
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException)
                    ViewBag.Message = ex.Message;
                return View();

            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinEvent(int Id)
        {
            try
            {
                if (await _unitOfWorkHttp.Members.JoinEvent(Id))
                {

                    return RedirectToAction("Index", "UserHome");
                }
                else if (!await _unitOfWorkHttp.Members.JoinEvent(Id))
                {
                    return RedirectToAction("Login", "UserHome");
                }
                return RedirectToAction("Index", "UserHome");
            }
            catch (Exception ex)
            {

                if (ex is HttpRequestException)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
                return View();

            }
        }


    }
}
