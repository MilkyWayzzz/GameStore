using GameStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Entities;
using GameStore.Domain.Queries;
using GameStore.Domain.ViewModels;

namespace GameStore.WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameQuaries quary;
        private IGameRepository repository;
        public int pageSize = 4;

        public GameController(IGameRepository repo, IGameQuaries qua)
        {
            quary = qua;
            repository = repo;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetGames(string category, int page = 1)
        {
            var query = repository.Games.Where(p => category == null || p.Category == category);

            var count = query.Count();

            query = query.OrderBy(game => game.GameId).Skip((page - 1) * pageSize).Take(pageSize);

            var model = new
            {
                games = query.ToArray(),
                pagecount = (int)Math.Ceiling((decimal)count / pageSize),
                CurrentPage = page
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public FileContentResult GetImage(int gameId)
        {
            Game game = repository.Games.FirstOrDefault(g => g.GameId == gameId);
            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}