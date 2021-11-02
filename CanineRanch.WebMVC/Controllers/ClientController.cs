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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var service = CreateClientService();
            var model = service.GetClients();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your Client was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Client could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientByID(id);
            var model =
                new ClientEdit
                {
                    ClientID = detail.ClientID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ClientID != id)
            {
                ModelState.AddModelError(" ", "ID Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = " Your client was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(" ", "Your client could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int id)
        {
            var service = CreateClientService();

            service.DeleteClient(id);

            TempData["SaveResult"] = "Your client was deleted";

            return RedirectToAction("Index");
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
    }
}