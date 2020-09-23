using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;
using System;

namespace GameManagement.Repositories
{
    public class GameLoanRepository : BaseRepository<GameLoan>, IGameLoanRepository
    {
        private static readonly string SELECT = @"SELECT GameLoans.*, count(*) OVER() AS count FROM GameLoans ";

        public GameLoanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public GameLoan FindGameLoansById(long id)
        {
            return FindById(SELECT, "id", id);
        }

        public PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate)
        {
            return FindByDateRange(SELECT, "loanDate", page, pageSize, initialDate, finalDate, "loanDate");
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
