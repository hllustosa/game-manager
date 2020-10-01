using GameManagement.Domain;
using System;
using System.Collections.Generic;

namespace GameManagement.Services.Interfaces
{
    public interface IGameLoanService
    {
        PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate);

        PagedResult<GameLoan> FindUserGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate, long friendId);

        List<GameLoan> FindGameLoansTimeline(long? friendId, long? gameId);

        GameLoan FindGameLoanById(long id);

        GameLoan Save(GameLoan gameLoan);

        GameLoan Update(long id, GameLoan gameLoan);

        void Delete(GameLoan gameLoan);
    }
}
