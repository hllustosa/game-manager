using GameManagement.Domain;
using GameManagement.Repositories.Interfaces;
using GameManagement.services.interfaces;

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
            Model.CheckModel(game);
            game.Validate();
            GameRepository.Save(game);
            return game;
        }

        public Game Update(long id, Game game)
        {
            Model.CheckModel(game);
            game.Validate();

            var currentGame = GameRepository.FindGamesById(id);

            Model.CheckModel(game);
            game.Id = currentGame.Id;
            game.IsLent = currentGame.IsLent;
            
            GameRepository.Update(game);
            return game;
        }

        public void Delete(Game game)
        {
            Model.CheckModel(game);
            GameRepository.Delete(game);
        }
    }
}
