using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class GamesController : Controller
    {
        IGameService GameService { get; set; }

        public GamesController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpGet("{id}")]
        public Game FindGameById(long id)
        {
            return GameService.FindGameById(id);
        }

        [HttpGet("{pageSize}/{page}/{name?}")]
        public PagedResult<Game> FindGamesByName(int page, int pageSize, string name)
        {
            return GameService.FindGamesByName(page, pageSize, name);
        }

        [HttpPost]
        public Game Save([FromBody]Game game)
        {
            return GameService.Save(game);
        }

        [HttpPut("{id}")]
        public Game Update(long id, [FromBody]Game game)
        {
            return GameService.Update(id, game);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            GameService.Delete(GameService.FindGameById(id));
        }
    }
}