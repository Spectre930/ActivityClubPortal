using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers
{
    public class UserLookupsController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserLookupsController(IUnitOfWorkHttp unitOfWorkHttp, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            var ResObject = await _unitOfWorkHttp.Lookups.GetAllAsync("Lookup");
            return View(ResObject);
        }

        public IActionResult Create()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LookupResource obj, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            obj.Id = 0;

            string wwwRootPath = _hostEnvironment.WebRootPath;
            obj.ImageUrl = file.FileName;
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images\lookups");
            var extension = Path.GetExtension(file.FileName);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                file.CopyTo(fileStreams);
            }
            obj.ImageUrl = @"\images\lookups\" + fileName + extension;

            try
            {
                await _unitOfWorkHttp.Lookups.CreatePostAsync("Lookup", obj);
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
            var lookups = await _unitOfWorkHttp.Lookups.GetAsync("Lookup", id);

            return View(lookups);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LookupResource lookup, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                lookup.ImageUrl = file.FileName;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\lookups");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                lookup.ImageUrl = @"\images\lookups\" + fileName + extension;
            }
            try
            {
                await _unitOfWorkHttp.Lookups.UpdatePostAsync("Lookup", lookup, lookup.Id);
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
            var ResObject = await _unitOfWorkHttp.Lookups.GetAsync("Lookup", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Lookups.DeleteAsync("Lookup", id);
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
