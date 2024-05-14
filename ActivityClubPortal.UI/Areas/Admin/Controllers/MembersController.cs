using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers
{
    public class MembersController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public MembersController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }

        public async Task<IActionResult> Index()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            var ResObject = await _unitOfWorkHttp.Members.GetAllAsync("Member");
            return View(ResObject);
        }

        public IActionResult Create()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberResource member)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            member.Id = 0;
            try
            {
                await _unitOfWorkHttp.Members.CreateMember(member);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException)
                    ViewBag.Message = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();

            var ResObject = await _unitOfWorkHttp.Members.GetAsync("Member", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberResource member)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Members.UpdateMemberAsync(member);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = $"error occured while editing please try again!,{ex.Message}";
                return View();
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            var ResObject = await _unitOfWorkHttp.Members.GetAsync("Member", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Members.DeleteAsync("Member", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while deleting please try again!";

                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> MemberEvents(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                var events = await _unitOfWorkHttp.Members.GetEvents(id);
                return View(events);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }

        }

    }
}
