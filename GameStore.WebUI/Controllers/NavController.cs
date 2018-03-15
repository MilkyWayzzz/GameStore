using GameStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGameRepository repository;
        public NavController(IGameRepository repo)
        {
            repository = repo;
        }
        public ActionResult Menu(string category = null)
        {
            //ViewBag.SelectedCategory = category;

            
            var model = new
            {
                categories = repository.Games.Select(game => game.Category).Distinct().OrderBy(x => x),
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}