using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Antaram_game.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayerController : Controller
    {
        [HttpGet("/player")]
        public IActionResult Player()
        {
            return View();
        }
    }
}
