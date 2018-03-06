using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
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
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(game);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", game.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(game);
            }
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

        public ViewResult Create()
        {
            return View("Edit", new Game());
        }
        public ActionResult Index()
        {
            return View(repository.Games);
        }
    }
}