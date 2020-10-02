using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class GameLoansController : Controller
    {
        IGameLoanService GameLoanService { get; set; }

        public GameLoansController(IGameLoanService gameLoanService)
        {
            GameLoanService = gameLoanService;
        }

        [HttpGet("{id}")]
        public GameLoan FindGameLoanById(long id)
        {
            return GameLoanService.FindGameLoanById(id);
        }

        [HttpGet]
        public PagedResult<GameLoan> FindGameLoansByDate([FromQuery]int page, [FromQuery]int pageSize, [FromQuery]DateTime? initialDate, [FromQuery]DateTime? finalDate)
        {
            return GameLoanService.FindGameLoansByDate(page, pageSize, initialDate, finalDate);
        }

        [HttpGet("friends/{friendId}")]
        public List<GameLoan> FindFriendsGameLoansTimeline(long friendId)
        {
            return GameLoanService.FindGameLoansTimeline(friendId, null);
        }

        [HttpGet("games/{gameId}")]
        public List<GameLoan> FindGamesGameLoansTimeline(long gameId)
        {
            return GameLoanService.FindGameLoansTimeline(null, gameId);
        }

        [HttpPost]
        public GameLoan Save([FromBody]GameLoan gameLoan)
        {
            return GameLoanService.Save(gameLoan);
        }

        [HttpPut("{id}")]
        public GameLoan Update(long id, [FromBody]GameLoan gameLoan)
        {
            return GameLoanService.Update(id, gameLoan);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            GameLoanService.Delete(GameLoanService.FindGameLoanById(id));
        }
    }
}