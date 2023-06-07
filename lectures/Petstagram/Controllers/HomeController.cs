using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Petstagram.Models;

namespace Petstagram.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

//----------below is for the add pet form-----------//
    [HttpPost("addPet")]
    public IActionResult AddPet(string Name, string Type, int Age)
    {
        Console.WriteLine($"{Name} is our newest pet! He is a {Type} and is {Age} year(s) old!");
        if(Type == "tortoise")
        {
            //you can use ViewBag to add form data and display it on another page here (will go to DB when we start using)
            ViewBag.SecretMessage = "You are a shiny pokemon!";
            ViewBag.Name = Name;
            ViewBag.Type = Type;
            ViewBag.Age = Age;
            return View("Secret");
        }
        return Redirect("/");
    }
//-----------------------end form-------------------------//

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("{**path}")]
    public RedirectResult Unknown() 
    {
        return Redirect("/");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
