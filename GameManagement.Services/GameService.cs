using GameManagement.Domain;
using GameManagement.Repositories.Interfaces;
using GameManagement.services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagement.Services
{
    public class GameService : IGameService
    {
        IGameRepository GameRepository {get; set;}

        public GameService(IGameRepository gameRepository)
        {
            GameRepository = gameRepository;
        }

        public Game FindGameById(long id)
        {
            return GameRepository.FindGamesById(id);
        }

        public PagedResult<Game> FindGamesByName(int page, int pageSize, string name)
        {
            return GameRepository.FindGamesByName(page, pageSize, name);
        }

        public Game Save(Game game)
        {
            game.Validate();
            GameRepository.Save(game);
            return game;
        }

        public Game Update(Game game)
        {
            game.Validate();
            //TODO: Make it impossible to change the game status from here
            GameRepository.Update(game);
            return game;
        }

        public void Delete(Game game)
        {
            GameRepository.Delete(game);
        }
    }
}
