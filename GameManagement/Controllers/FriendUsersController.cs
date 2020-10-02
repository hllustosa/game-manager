using GameManagement.Domain;
using GameManagement.Infra;
using GameManagement.Repositories.Interfaces;
using GameManagement.services.interfaces;
using GameManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GameManagement.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Policy = GameManagerServices.FRIEND_ROLE_POLICY)]
    public class FriendUsersController : Controller
    {
        IGameService GameService { get; set; }

        IGameLoanService GameLoanService { get; set; }

        IFriendRepository FriendRepository { get; set; }

        IUserService UserService { get; set; }

        public FriendUsersController(IGameService gameService,
            IGameLoanService gameLoanService, 
            IFriendRepository friendRepository, 
            IUserService userService)
        {
            GameService = gameService;
            GameLoanService = gameLoanService;
            FriendRepository = friendRepository;
            UserService = userService;
        }

        [HttpGet("games")]
        public PagedResult<Game> FindGamesByName([FromQuery]int page, [FromQuery]int pageSize, [FromQuery]string name)
        {
            return GameService.FindGamesByName(page, pageSize, name);
        }

        [HttpGet("loans")]
        public PagedResult<GameLoan> FindGameLoansByDate([FromQuery]int page, [FromQuery]int pageSize, [FromQuery]DateTime? initialDate = null, [FromQuery]DateTime? finalDate = null)
        {
            var currentUser = UserService.GetCurrentUser();
            var friend = FriendRepository.FindFriendByUserId(currentUser.UserId);
            return GameLoanService.FindUserGameLoansByDate(page, pageSize, initialDate, finalDate, friend.Id);
        }
    }
}