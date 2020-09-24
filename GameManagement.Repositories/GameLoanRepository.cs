using Dapper;
using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameManagement.Repositories
{
    public class GameLoanRepository : BaseRepository<GameLoan>, IGameLoanRepository
    {
        private static readonly string SELECT = @"SELECT GameLoans.*, 0 sp0, Friends.*, 0 sp1, Games.*, count(*) OVER() AS count 
                                                    FROM GameLoans 
                                                    INNER JOIN Friends ON Friends.Id = GameLoans.FriendId
                                                    INNER JOIN Games ON Games.Id = GameLoans.GameId ";

        private static readonly string SELECT_SIMPLE = @"SELECT GameLoans.*, count(*) OVER() AS count 
                                                    FROM GameLoans  ";

        private static readonly string BETWEEN_FILTER = @"WHERE {0} BETWEEN :initialDate AND :finalDate ";

        private static readonly string FRIEND_FILTER = @"WHERE {0} BETWEEN :initialDate AND :finalDate AND GameLoans.FriendId = :friendId ";

        private static readonly string ORDER_BY = @"ORDER BY {0} DESC ";

        private static readonly string PAGINATION = @"LIMIT :limit offset :offset ";

        public GameLoanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public GameLoan FindGameLoansById(long id)
        {
            return FindById(SELECT_SIMPLE, "Id", id);
        }

        private PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate, long? friendId)
        {
            var limit = pageSize;
            var offset = (page - 1) * pageSize;
            long totalCount = 0;
            var whereClause = "";

            if (friendId == null && (initialDate != null || finalDate != null))
            {
                whereClause = String.Format(BETWEEN_FILTER, "LoanDate");
            }
            else if (friendId != null)
            {
                whereClause = String.Format(FRIEND_FILTER, "LoanDate");
            }

            initialDate = initialDate == null ? DateTime.MinValue : initialDate;
            finalDate = finalDate == null ? DateTime.MaxValue : finalDate;

            var query = SELECT;
            query += whereClause;
            query += String.Format(ORDER_BY, "LoanDate");
            query += PAGINATION;

            var connection = ApplicationDbContext.Database.GetDbConnection();
            var models = connection.Query<GameLoan, Friend, Game, long, GameLoan>(query,
                (gameLoan, friend, game, count) =>
                {
                    gameLoan.Friend = friend;
                    gameLoan.Game = game;
                    totalCount = count;
                    return gameLoan;
                },
                new { initialDate, finalDate, friendId, limit, offset },
                splitOn: "sp0, sp1, count").AsList();

            return new PagedResult<GameLoan>(models, page, totalCount);
        }

        public PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate)
        {
            return FindGameLoansByDate(page, pageSize, initialDate, finalDate, null);
        }

        public PagedResult<GameLoan> FindUserGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate, long friendId)
        {
            return FindGameLoansByDate(page, pageSize, initialDate, finalDate, friendId);
        }

        public new void Save(GameLoan gameLoan)
        {
            base.Save(gameLoan);
        }

        public new void Update(GameLoan gameLoan)
        {
            base.Update(gameLoan);
        }

        public new void Delete(GameLoan gameLoan)
        {
            base.Delete(gameLoan);
        }

 
    }
}
