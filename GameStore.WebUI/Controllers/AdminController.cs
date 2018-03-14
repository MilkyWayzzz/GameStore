using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ViewResult Edit(int gameId)
        {
            Game game = repository.Games.FirstOrDefault(g => g.GameId == gameId);
            return View(game);
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
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", game.Name);
                return Json(game.GameId, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete (int gameId)
        {
            Game deleteGame = repository.DeleteGame(gameId);
            if (deleteGame !=null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена", deleteGame);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create(Game game)
        {
            repository.Create(game);
            return View("Index");
        }
        public ActionResult GetGames ()
        {
            var model = JsonConvert.SerializeObject(repository.Games);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View(repository.Games);
        }
    }
}