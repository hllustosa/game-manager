﻿using System;
using System.Collections.Generic;
using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;
using GameManagement.Services.Interfaces;

namespace GameManagement.Services
{
    public class GameLoanService : IGameLoanService
    {
        ApplicationDbContext ApplicationDbContext { get; set; }

        IGameLoanRepository GameLoanRepository { get; set; }

        IGameRepository GameRepository { get; set; }

        IFriendRepository FriendRepository { get; set; }

        IDateService DateService { get; set; }

        public GameLoanService(ApplicationDbContext applicationDbContext, 
            IGameLoanRepository gameLoanRepository, 
            IGameRepository gameRepository, 
            IFriendRepository friendRepository, 
            IDateService dateService)
        {
            ApplicationDbContext = applicationDbContext;
            GameLoanRepository = gameLoanRepository;
            GameRepository = gameRepository;
            FriendRepository = friendRepository;
            DateService = dateService;
        }

        private void ValidateGameLoan(GameLoan gameLoan, Game game)
        {
            if (game == null)
            {
                throw new GameManagerException(new List<ValidationError>()
                {
                    new ValidationError()
                    {
                        DataField = "GameId",
                        ErrorMsg = "Game inválido"
                    }
                });
            }

            if (game.IsLent)
            {
                throw new GameManagerException(new List<ValidationError>()
                {
                    new ValidationError()
                    {
                        DataField = "GameId",
                        ErrorMsg = "O Jogo Selecionado já está emprestado"
                    }
                });
            }

            var friend = FriendRepository.FindFriendById(gameLoan.FriendId);
            if (friend == null)
            {
                throw new GameManagerException(new List<ValidationError>()
                {
                    new ValidationError()
                    {
                        DataField = "FriendId",
                        ErrorMsg = "Amigo inválido"
                    }
                });
            }
        }

        private GameLoan GetCurrentGameLoan(long id)
        {
            var currentGameLoan = GameLoanRepository.FindGameLoansById(id);
            if (currentGameLoan == null)
            {
                throw new GameManagerException(new List<ValidationError>()
                {
                    new ValidationError()
                    {
                        DataField = "Id",
                        ErrorMsg = "Empréstimo inválido"
                    }
                });
            }

            return currentGameLoan;
        }

        private void RegisterGameReturn(GameLoan gameLoan)
        {
            var currentGameLoan = GetCurrentGameLoan(gameLoan.Id);

            if (currentGameLoan.IsActive)
            {
                var loanedGame = GameRepository.FindGamesById(currentGameLoan.GameId);
                loanedGame.IsLent = false;
                gameLoan.IsActive = false;
                gameLoan.LoanDate = currentGameLoan.LoanDate;
                gameLoan.ReturnDate = DateService.GetCurrentDate();

                GameRepository.Update(loanedGame);
                GameLoanRepository.Update(gameLoan);
            }
        }

        private void UpdateGameLoan(GameLoan gameLoan)
        {
            var currentGameLoan = GetCurrentGameLoan(gameLoan.Id);

            //If the game is being changed
            if(gameLoan.GameId != currentGameLoan.GameId)
            {
                //Releasing current game
                var loanedGame = GameRepository.FindGamesById(currentGameLoan.GameId);
                loanedGame.IsLent = false;
                GameRepository.Update(loanedGame);

                var game = GameRepository.FindGamesById(gameLoan.GameId);
                ValidateGameLoan(gameLoan, game);
                gameLoan.LoanDate = currentGameLoan.LoanDate;
                GameRepository.Update(loanedGame);
                GameLoanRepository.Update(gameLoan);
            }
            else
            {
                var game = GameRepository.FindGamesById(gameLoan.GameId);
                gameLoan.LoanDate = currentGameLoan.LoanDate;
                GameLoanRepository.Update(gameLoan);
            }
        }

        public GameLoan FindGameLoanById(long id)
        {
            return GameLoanRepository.FindGameLoansById(id);
        }

        public PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate)
        {
            return GameLoanRepository.FindGameLoansByDate(page, pageSize, initialDate, finalDate);
        }

        public PagedResult<GameLoan> FindUserGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate, long friendId)
        {
            return GameLoanRepository.FindUserGameLoansByDate(page, pageSize, initialDate, finalDate, friendId);
        }

        public List<GameLoan> FindGameLoansTimeline(long? friendId, long? gameId)
        {
            return GameLoanRepository.FindGameLoansTimeline(friendId, gameId);
        }

        public GameLoan Save(GameLoan gameLoan)
        {
            try
            {
                ApplicationDbContext.Database.BeginTransaction();
                Model.CheckModel(gameLoan);

                var game = GameRepository.FindGamesById(gameLoan.GameId);
                ValidateGameLoan(gameLoan, game);

                //Setting data
                game.IsLent = true;
                gameLoan.LoanDate = DateService.GetCurrentDate();
                gameLoan.ReturnDate = null;

                //Saving
                GameRepository.Update(game);
                GameLoanRepository.Save(gameLoan);

                ApplicationDbContext.Database.CommitTransaction();
            }
            catch(Exception e)
            {
                ApplicationDbContext.Database.RollbackTransaction();
                throw e;
            }

            return gameLoan;
        }

        public GameLoan Update(long id, GameLoan gameLoan)
        {
            try
            {
                Model.CheckModel(gameLoan);
                gameLoan.Id = id;

                ApplicationDbContext.Database.BeginTransaction();
               
                if(!gameLoan.IsActive)
                {
                    RegisterGameReturn(gameLoan);
                }
                else
                {
                    UpdateGameLoan(gameLoan);
                }

                ApplicationDbContext.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                ApplicationDbContext.Database.RollbackTransaction();
                throw e;
            }

            return gameLoan;
        }

        public void Delete(GameLoan gameLoan)
        {
            try
            {
                ApplicationDbContext.Database.BeginTransaction();
                Model.CheckModel(gameLoan);

                gameLoan = ApplicationDbContext.GameLoans.Find(gameLoan.Id);
                var game = ApplicationDbContext.Games.Find(gameLoan.GameId);
                game.IsLent = false;
                GameRepository.Update(game);
                GameLoanRepository.Delete(gameLoan);
                ApplicationDbContext.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                ApplicationDbContext.Database.RollbackTransaction();
                throw e;
            }
        }
    }
}
