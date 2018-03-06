using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using GameStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Queries
{
    public class EFGameQuaries : IGameQuaries
    {
        EFDbContext db = new EFDbContext();
        public GameViewModel Get(int page, int pageSize)
        {
            double count = db.Games.Count();
            var pages = count % pageSize;
            if (pages == 0)
            {
                pages = count / pageSize;
            }
            else
            {
                pages = (int)(count / pageSize) + 1;
            }
            return new GameViewModel
            {
                Games = db.Games.OrderBy(x => x.GameId).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (int) count
                }
            };

        }
    }
}
