using Microsoft.AspNet.Identity;
using PokemonCollection.Models.PokemonModels;
using PokemonCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonCollection.WebMVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        [Authorize]
        public ActionResult Index()
        {
            //var model = new PokemonListItem[0];
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PokemonService(userId);
            var model = service.GetAllPokemon();

            return View(model);
        }

        public ActionResult Create()
        {
            //bring in services to call get all regions
            //bring in services to call get all types
            //You'll use those variables to populate the SelectList
            //ViewBag object assigned the value of a SelectList object that will be used to make a dropdown for existing regions in database
            //Do the same for Type
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PokemonCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreatePokemonService();

            if (service.CreatePokemon(model))
            {
                TempData["SaveResult"] = "Your Pokemon was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Pokmemon could not be added.");

            return View(model);
        }

        private PokemonService CreatePokemonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PokemonService(userId);
            return service;            
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePokemonService();
            var model = svc.GetPokemonById(id);

            return View(model);
        }
    }
}