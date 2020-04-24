using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonCollection.WebMVC.Controllers
{
    public class PokedexController : Controller
    {
        // GET: Pokedex
        public ActionResult Index()
        {
            return View();
        }
    }
}