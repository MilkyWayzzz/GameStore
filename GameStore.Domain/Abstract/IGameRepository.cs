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
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
    }
}
