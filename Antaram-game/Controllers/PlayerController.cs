using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Antaram_game.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerController : Controller
    {
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
    }
}
