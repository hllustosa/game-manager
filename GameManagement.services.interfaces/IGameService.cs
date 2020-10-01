using GameManagement.Domain;

namespace GameManagement.services.interfaces
{
    public interface IGameService
    {
        PagedResult<Game> FindGamesByName(int page, int pageSize, string name);

        Game FindGameById(long id);

        Game Save(Game game);

        Game Update(long id, Game game);

        void Delete(Game game);
    }
}
