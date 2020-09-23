﻿using GameManagement.Domain;
using System;

namespace GameManagement.Repositories.Interfaces
{
    public interface IGameLoanRepository
    {
        PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate);

        GameLoan FindGameLoansById(long id);

        void Save(GameLoan gameLoan);

        void Update(GameLoan gameLoan);

        void Delete(GameLoan gameLoan);
    }
}