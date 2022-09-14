using Antaram_game.Models.DTOs;
using Antaram_game.Services;
using Microsoft.AspNetCore.Mvc;

namespace Antaram_game.Controllers
{
    public class PublicController : Controller
    {
        private readonly IPublicService _publicService;

        public PublicController(IPublicService publicService)
        {
            _publicService = publicService;
        }

        [HttpGet("")]
        public IActionResult Index(string message)
        {          
            return View(new ResponseDto(message));
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register(string name, string password)
        {
            var credentials = new UserRegistrationDto(name, password);
            var response = _publicService.Register(credentials);
            if (response.Equals("New user has been created"))
            {
                return new RedirectResult("/?message=New user has been created");                
            }

            return View(new ResponseDto(response));
        }
    }
}
