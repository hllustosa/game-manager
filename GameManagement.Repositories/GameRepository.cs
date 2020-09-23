using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;

namespace GameManagement.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private static readonly string SELECT = @"SELECT Games.*, count(*) OVER() AS count FROM Games ";

        public GameRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
        }

        public Game FindGamesById(long id)
        {
            return FindById(SELECT, "id", id);
        }

        public PagedResult<Game> FindGamesByName(int page, int pageSize, string name)
        {
            return FindLike(SELECT, "name", name, page, pageSize);
        }

        public new void Save(Game game)
        {
            base.Save(game);
        }

        public new void Update(Game game)
        {
            base.Update(game);
        }

        public new void Delete(Game game)
        {
            base.Delete(game);
        }
    }
}
