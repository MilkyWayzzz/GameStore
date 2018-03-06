using Dapper;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Queries
{
    public class DapperGameQuaries : IGameQuaries
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString;
        public GameViewModel Get(int page, int pageSize)
        {
            List<Game> games = new List<Game>();
            int pages;
            int count;
            int skip = (page - 1) * pageSize;
            int rowNumber = skip + pageSize + 1;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                count = db.Query<int>("SELECT COUNT(*) FROM Games").Single();
                pages = count % pageSize;
                if (pages == 0)
                {
                    pages = count / pageSize;
                }
                else
                {
                    pages = (int)(count / pageSize) + 1;
                }
                string query = "SELECT  *FROM(SELECT ROW_NUMBER() OVER(ORDER BY GameId) AS RowNum, * FROM Games) AS result WHERE RowNum > @skip AND RowNum < @rowNumber";
                games = db.Query<Game>(query, new { skip = skip, rowNumber = rowNumber }).ToList();
            }
            return new GameViewModel
            {
                Games = games,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (int)count
                }
            };
        }
    }
}
