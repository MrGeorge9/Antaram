using Antaram_game.Models.DTOs;
using Antaram_game.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Antaram_game.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("/mainmenu")]
        public IActionResult MainMenu()
        {
            return View();
        }

        [HttpGet("/charcreation")]
        public IActionResult CharacterCreation()
        {            
            return View();
        }

        [HttpPost("/charcreation")]
        public IActionResult CharacterCreation(string race, string style, string name)
        {            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = identity.Claims;
            var response = _playerService.CharacterCreation(race, style, name, userClaims);

            if (response.Equals("Character with that name already exists"))
            {
                return View(new ResponseDto(response));
            }
            return new RedirectResult("/mainmenu");
        }
    }
}
