using PokemonCollection.Models.PokemonModels;
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
            var model = new PokemonListItem[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PokemonCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}