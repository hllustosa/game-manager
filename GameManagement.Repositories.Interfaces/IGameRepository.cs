using GameManagement.Domain;

namespace GameManagement.Repositories.Interfaces
{
    public interface IGameRepository
    {
        PagedResult<Game> FindGamesByName(int page, int pageSize, string name);

        Game FindGamesById(long id);

        void Save(Game game);

        void Update(Game game);

        void Delete(Game game);
    }
}
