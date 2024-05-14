using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers
{
    public class GuidesController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GuidesController(IUnitOfWorkHttp unitOfWorkHttp, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            var ResObject = await _unitOfWorkHttp.Guides.GetAllAsync("Guide");
            return View(ResObject);
        }

        public IActionResult Create()
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuideResource Guide, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            Guide.Id = 0;

            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                Guide.ImageUrl = file.FileName;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\guides");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                Guide.ImageUrl = @"\images\guides\" + fileName + extension;
            }

            try
            {
                await _unitOfWorkHttp.Guides.CreatePostAsync("Guide", Guide);
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

            var ResObject = await _unitOfWorkHttp.Guides.GetAsync("Guide", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GuideResource guide, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                guide.ImageUrl = file.FileName;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\guides");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                guide.ImageUrl = @"\images\guides\" + fileName + extension;
            }

            try
            {
                await _unitOfWorkHttp.Guides.UpdatePostAsync("Guide", guide, guide.Id);
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
            var ResObject = await _unitOfWorkHttp.Guides.GetAsync("Guide", id);

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Guides.DeleteAsync("Guide", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while deleting please try again!";

                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GuideEvents(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                var events = await _unitOfWorkHttp.Guides.GetEvents(id);
                return View(events);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GuideAnEvent(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                var GuidedEvents = await _unitOfWorkHttp.Guides.GetEvents(id);
                var Ids = GuidedEvents.Select(x => x.Id).ToList();

                var AllEvents = await _unitOfWorkHttp.Events.GetEvents();

                var RemainedEvents = AllEvents.Where(x => !Ids.Contains(x.Event.Id)).ToList();
                ViewBag.GuideId = id;
                return View(RemainedEvents);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostGuideAnEvent(int GuideId, int EventId)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();

            await _unitOfWorkHttp.Guides.GuideAnEvent(GuideId, EventId);
            return RedirectToAction("Index");

        }
    }
}
