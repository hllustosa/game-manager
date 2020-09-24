using GameManagement.Domain;
using System;
using System.Collections.Generic;

namespace GameManagement.Repositories.Interfaces
{
    public interface IGameLoanRepository
    {
        PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate);

        PagedResult<GameLoan> FindUserGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate, long friendId);

        List<GameLoan> FindGameLoansTimeline(long? friendId, long? gameId);

        GameLoan FindGameLoansById(long id);

        void Save(GameLoan gameLoan);

        void Update(GameLoan gameLoan);

        void Delete(GameLoan gameLoan);
    }
}
