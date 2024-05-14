using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;

        public AdminsController(IUnitOfWorkHttp unitOfWorkHttp)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
        }
        public async Task<IActionResult> Index()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            var ResObject = await _unitOfWorkHttp.Users.GetAllAsync("User");
            return View(ResObject);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserResource user)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            user.Id = 0;
            try
            {
                await _unitOfWorkHttp.Users.CreatePostAsync("User", user);
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
            var ResObject = await _unitOfWorkHttp.Users.GetAsync("User", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserResource user)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Users.UpdatePostAsync("User", user, user.Id);
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
            var ResObject = await _unitOfWorkHttp.Users.GetAsync("User", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Users.DeleteAsync("User", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while deleting please try again!";

                return View();
            }

        }
    }
}
