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
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var service = CreateDogService();
            var model = service.GetDogs();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDogService();

            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Your Dog was craeted.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Dog could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDogService();
            var detail = service.GetDogByID(id);
            var model =
                new DogEdit
                {
                    DogID = detail.DogID,
                    DogName = detail.DogName,
                    Breed = detail.Breed,
                    Age = detail.Age,
                    IsFixed = detail.IsFixed
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DogID != id)
            {
                ModelState.AddModelError(" ", "ID Mismatch");
                return View(model);
            }

            var service = CreateDogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "Your dog was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Your dog could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDog(int id)
        {
            var service = CreateDogService();

            service.DeleteDog(id);

            TempData["SaveResult"] = "Your dog was deleted";

            return RedirectToAction("Index");
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }
    }
}