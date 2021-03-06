﻿using GameStore.Domain.Abstract;
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
        public ViewResult List(string category, int page = 1)
        {
            GameViewModel model = new GameViewModel
            {
                Games = repository.Games.Where(p => category == null || p.Category == category).OrderBy(game => game.GameId).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null? repository.Games.Count() : repository.Games.Where(game=>game.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        //public ViewResult List(int page = 1) //new version
        //{   
        //    return View(quary.Get(page, pageSize));
        //}
    }
}