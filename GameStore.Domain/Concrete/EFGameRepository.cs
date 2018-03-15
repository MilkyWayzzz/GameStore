using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        EFDbContext db = new EFDbContext();

        public IQueryable<Game> Games
        {
            get { return db.Games.AsQueryable(); }
        }

        public void Add(Game game)
        {
            db.Games.Add(game);

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = db.Games.Where(x => x.GameId == id).FirstOrDefault();

            db.Games.Remove(game);

            db.SaveChanges();
        }

        public void Update(Game game)
        {
            var gamedb = db.Games.Where(x => x.GameId == game.GameId).FirstOrDefault();

            gamedb.Name = game.Name;
            gamedb.Description = game.Description;
            gamedb.Category = game.Category;
            gamedb.Price = game.Price;
            gamedb.ImageData = game.ImageData;
            gamedb.ImageMimeType = game.ImageMimeType;

            db.SaveChanges();
        }
    }
}
