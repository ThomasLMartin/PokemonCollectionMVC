using Microsoft.AspNet.Identity;
using PokemonCollection.Models.TypeModel;
using PokemonCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonCollection.WebMVC.Controllers
{
    public class TypeController : Controller
    {
        // GET: Type
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TypeService(userId);
            var model = service.GetAllTypes();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateTypeService();

            if (service.CreateType(model))
            {
                TempData["SaveResult"] = "Your Type was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The Type could not be added.");

            return View(model);
        }

        private TypeService CreateTypeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TypeService(userId);
            return service;
        }
    }
}