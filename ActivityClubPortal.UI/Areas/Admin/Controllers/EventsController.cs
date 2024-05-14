using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ActivityClubPortal.UI.Areas.Admin.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWorkHttp _unitOfWorkHttp;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EventsController(IUnitOfWorkHttp unitOfWorkHttp, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWorkHttp = unitOfWorkHttp;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var ResObject = await _unitOfWorkHttp.Events.GetEvents();
            return View(ResObject);
        }

        public async Task<IActionResult> Create()
        {
            var list = await _unitOfWorkHttp.Lookups.GetAllAsync("Lookup");
            var resObj = new EventsPostVm
            {
                Event = new(),
                LookupList = list.Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(resObj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventsPostVm obj, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            obj.Event.Id = 0;

            string wwwRootPath = _hostEnvironment.WebRootPath;
            obj.Event.ImageUrl = file.FileName;
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images\events");
            var extension = Path.GetExtension(file.FileName);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                file.CopyTo(fileStreams);
            }
            obj.Event.ImageUrl = @"\images\events\" + fileName + extension;

            try
            {
                await _unitOfWorkHttp.Events.CreatePostAsync("Event", obj.Event);
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
            var lookups = await _unitOfWorkHttp.Lookups.GetAllAsync("Lookup");
            var e = await _unitOfWorkHttp.Events.GetEvent(id);

            EventsPostVm ResObject = new()
            {
                Event = e.Event,
                LookupList = lookups.Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(ResObject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventsPostVm ev, IFormFile? file)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                ev.Event.ImageUrl = file.FileName;
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\events");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                ev.Event.ImageUrl = @"\images\events\" + fileName + extension;
            }
            else
            {
            }
            try
            {
                await _unitOfWorkHttp.Events.UpdatePostAsync("Event", ev.Event, ev.Event.Id);
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
            var ResObject = await _unitOfWorkHttp.Events.GetEvent(id);

            return View(ResObject.Event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Events.DeleteAsync("Event", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while deleting please try again!";

                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> EventMembers(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                var members = await _unitOfWorkHttp.Events.GetMembers(id);
                return View(members);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> EventGuides(int id)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                var guides = await _unitOfWorkHttp.Events.GetEventGuides(id);
                return View(guides);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGuide(int EventId, int GuideId)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Events.AddGuide(EventId, GuideId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while adding please try again!";

                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DropGuide(int EventId, int GuideId)
        {
            _unitOfWorkHttp.Users.AuthorizeHeader();
            try
            {
                await _unitOfWorkHttp.Events.DropGuide(EventId, GuideId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Message = "error occured while dropping please try again!";

                return View();
            }

        }


    }
}
