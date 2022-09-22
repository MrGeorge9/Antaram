﻿using Antaram_game.Context;
using Antaram_game.Models.DTOs;
using Antaram_game.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Antaram_game.Controllers
{
    public class PublicController : Controller
    {
        private readonly IPublicService _publicService;
        private readonly IAuthService _jwtService;
        private readonly ApplicationContext _db;

        public PublicController(IPublicService publicService, IAuthService jwtService, ApplicationContext db)
        {
            _publicService = publicService;
            _jwtService = jwtService;
            _db = db;
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
                return new RedirectResult($"/?message={response}");                
            }

            return View(new ResponseDto(response));
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult Login(string name, string password)
        {
            var credentials = new UserLoginDto(name, password);
            var response = _publicService.Login(credentials);

            var user = _db.Users.FirstOrDefault(p => p.Name.Equals(name));

            HttpContext.Response.Headers.SetCookie = $"jwt={_jwtService.GenerateToken(user)}";            
            if (response.Equals("Successfully logged in"))
            {
                return new RedirectResult($"/?message={response}");
            }

            return View(new ResponseDto(response));
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {       
            HttpContext.Response.Cookies.Delete("jwt");
            return new RedirectResult("/");
        }

        [HttpGet("/user")]
        public IActionResult User()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaims = identity.Claims;
            var user = _jwtService.ReturnUserFromToken(userClaims);            
            return new RedirectResult("/");
        }
        
    }
}
