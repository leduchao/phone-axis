﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhoneAxis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to PhoneAxis Home page");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return Ok("Welcome to PhoneAxis Contact page");
        }
    }
}
