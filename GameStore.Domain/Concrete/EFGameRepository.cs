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
        public IEnumerable<Game> Games
        {
            get { return db.Games;}
        }
        public void Create(Game game)
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

        public Game DeleteGame(int gameid)
        {
            Game dbEntry = db.Games.Find(gameid);
            if (dbEntry != null)
            {
                db.Games.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }

        //public void SaveGame(Game game)
        //{
        //    if (game.GameId == 0)
        //        db.Games.Add(game);
        //    else
        //    {
        //        Game dbEntry = db.Games.Find(game.GameId);
        //        if (dbEntry !=null)
        //        {
        //            dbEntry.Name = game.Name;
        //            dbEntry.Description = game.Description;
        //            dbEntry.Price = game.Price;
        //            dbEntry.Category = game.Category;
        //            dbEntry.ImageData = game.ImageData;
        //            dbEntry.ImageMimeType = game.ImageMimeType;
        //        }
        //    }
        //    db.SaveChanges();
        //}

        public void Update(Game game)
        {
            var gamedb = db.Games.Where(x => x.GameId == game.GameId).FirstOrDefault();
            gamedb.Name = game.Name;
            gamedb.Description = game.Description;
            gamedb.Category = game.Category;
            gamedb.Price = game.Price;
            db.SaveChanges();
        }
    }
}
