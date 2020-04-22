using Microsoft.AspNet.Identity;
using PokemonCollection.Models.RegionModels;
using PokemonCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonCollection.WebMVC.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RegionService(userId);
            var model = service.GetAllRegions();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateRegionService();

            if (service.CreateRegion(model))
            {
                TempData["SaveResult"] = "Your Region was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Region could not be added.");

            return View(model);
        }

        private RegionService CreateRegionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RegionService(userId);
            return service;
        }
    }
}