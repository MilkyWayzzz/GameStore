using Dapper;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameStore.Domain.Concrete
{
    public class DapperGameRepository : IGameRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString;

        public IEnumerable<Game> Games
        {
            get
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<Game>("SELECT * FROM Games").ToList();
                }
            }
        }

        public void Create(Game game)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Games (Name, Price, CompanyId) VALUES(@Name, @Price, @CompanyId); SELECT CAST(SCOPE_IDENTITY() as int)";
                db.Execute(sqlQuery,game);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Games WHERE GameId = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Game DeleteGame(int gameid)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Games SET Name = @Name, Price = @Price, CompanyId = @CompanyId WHERE GameId = @GameId";
                db.Execute(sqlQuery, game);
            }
        }
    }
}
