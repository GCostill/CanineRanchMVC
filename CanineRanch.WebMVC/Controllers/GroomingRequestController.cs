using CanineRanch.Data;
using CanineRanch.Models;
using CanineRanch.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanineRanch.WebMVC.Controllers
{
    public class GroomingRequestController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
        // GET: GroomingRequest
        public ActionResult Index()
        {
            var service = CreateGroomingRequestService();
            var model = service.GetGroomingRequests();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.DogNames = _ctx.Dogs.Select(dogs => new SelectListItem
            {
                Text = dogs.DogName,
                Value = dogs.DogID.ToString()
            });

            ViewBag.LastName = _ctx.Clients.Select(lastNames => new SelectListItem
            {
                Text = lastNames.LastName,
                Value = lastNames.ClientID.ToString()
            });

            return View(new GroomingRequestCreate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroomingRequestCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateGroomingRequestService();

            if (service.CreateGroomingRequest(model))
            {
                TempData["SaveResult"] = "Your request was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Request could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGroomingRequestService();
            var model = svc.GetGroomingRequestByID(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGroomingRequestService();
            var model = svc.GetGroomingRequestByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int id)
        {
            var service = CreateGroomingRequestService();

            service.DeleteGroomingRequest(id);

            TempData["SaveResult"] = "Your grooming request was deleted";

            return RedirectToAction("Index");
        }

        private GroomingRequestService CreateGroomingRequestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GroomingRequestService(userId);
            return service;
        }
    }
}