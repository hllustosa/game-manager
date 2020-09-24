using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = GameManagerServices.ADMIN_ROLE_POLICY)]
    public class GameLoanController : Controller
    {
        IGameLoanService GameLoanService { get; set; }

        public GameLoanController(IGameLoanService gameLoanService)
        {
            GameLoanService = gameLoanService;
        }

        [HttpGet("[action]")]
        public GameLoan FindGameLoanById(long id)
        {
            return GameLoanService.FindGameLoanById(id);
        }

        [HttpGet("[action]")]
        public PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate)
        {
            return GameLoanService.FindGameLoansByDate(page, pageSize, initialDate, finalDate);
        }

        [HttpPost("[action]")]
        public GameLoan Save([FromBody]GameLoan gameLoan)
        {
            return GameLoanService.Save(gameLoan);
        }

        [HttpPost("[action]")]
        public GameLoan Update([FromBody]GameLoan gameLoan)
        {
            return GameLoanService.Update(gameLoan);
        }

        [HttpPost("[action]")]
        public void Delete([FromBody]GameLoan gameLoan)
        {
            GameLoanService.Delete(gameLoan);
        }
    }
}