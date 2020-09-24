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
    [Route("[controller]")]
    [Authorize(Policy = GameManagerServices.FRIEND_ROLE_POLICY)]
    public class FriendUserController : Controller
    {
        IGameService GameService { get; set; }

        IGameLoanService GameLoanService { get; set; }

        IFriendRepository FriendRepository { get; set; }

        IUserService UserService { get; set; }

        public FriendUserController(IGameService gameService,
            IGameLoanService gameLoanService, 
            IFriendRepository friendRepository, 
            IUserService userService)
        {
            GameService = gameService;
            GameLoanService = gameLoanService;
            FriendRepository = friendRepository;
            UserService = userService;
        }

        [HttpGet("[action]")]
        public PagedResult<Game> FindGamesByName(int page, int pageSize, string name)
        {
            return GameService.FindGamesByName(page, pageSize, name);
        }

        [HttpGet("[action]")]
        public PagedResult<GameLoan> FindGameLoansByDate(int page, int pageSize, DateTime? initialDate, DateTime? finalDate)
        {
            var currentUser = UserService.GetCurrentUser();
            var friend = FriendRepository.FindFriendByUserId(currentUser.UserId);
            return GameLoanService.FindUserGameLoansByDate(page, pageSize, initialDate, finalDate, friend.Id);
        }
    }
}