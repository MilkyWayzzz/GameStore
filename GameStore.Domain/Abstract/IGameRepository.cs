using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Abstract
{
    public interface IGameRepository
    {
        IQueryable<Game> Games { get; }

         void Create(Game game);

         void Delete(int id);

         void Update(Game game);
        // void SaveGame(Game game);
         Game DeleteGame(int gameid);
        
    
    }
}
