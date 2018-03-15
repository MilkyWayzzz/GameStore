using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IGameRepository repository;
        public AdminController(IGameRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGames()
        {
            var model = JsonConvert.SerializeObject(repository.Games.ToArray());

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Game game, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                game.ImageMimeType = image.ContentType;
                game.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(game.ImageData, 0, image.ContentLength);
            }

            repository.Add(game);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
      
        [HttpPost]
        public ActionResult Edit(Game game, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                game.ImageMimeType = image.ContentType;
                game.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(game.ImageData, 0, image.ContentLength);
            }

            repository.Update(game);

            return Json(game.GameId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete (int gameId)
        {
            repository.Delete(gameId);
            
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}