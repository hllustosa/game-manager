using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class GameController : Controller
    {
        IGameService GameService { get; set; }

        public GameController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpGet("[action]")]
        public PagedResult<Game> FindGamesByName(int page, int pageSize, string name)
        {
            return GameService.FindGamesByName(page, pageSize, name);
        }

        [HttpGet("[action]")]
        public Game FindGamesById(long id)
        {
            return GameService.FindGamesById(id);
        }

        [HttpPost("[action]")]
        public Game Save([FromBody]Game game)
        {
            return GameService.Save(game);
        }

        [HttpPost("[action]")]
        public Game Update([FromBody]Game game)
        {
            return GameService.Save(game);
        }

        [HttpPost("[action]")]
        public void Delete([FromBody]Game game)
        {
            GameService.Delete(game);
        }
    }
}