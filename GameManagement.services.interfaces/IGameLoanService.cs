using GameManagement.Domain;
using System;

namespace GameManagement.Services.Interfaces
{
    public interface IGameLoanService
    {
        PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate);

        GameLoan FindGameLoansById(long id);

        GameLoan Save(GameLoan gameLoan);

        GameLoan Update(GameLoan gameLoan);

        void Delete(GameLoan gameLoan);
    }
}
