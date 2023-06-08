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
    public IActionResult AddPet(Pet newPet)
    {
        //this is saying if model state is not valid, keep user in Index page to display error msgs
        if(!ModelState.IsValid)
        {
            return View("Index");
        }
        Console.WriteLine($"{newPet.Name} is our newest pet! He is a {newPet.Type} and is {newPet.Age} year(s) old!");
        if(newPet.Type == "tortoise")
        {
            //you can use ViewBag to add form data and display it on another page here (will go to DB when we start using)
            ViewBag.SecretMessage = "You are a shiny pokemon!";
            return View("Secret", newPet);
        }
        return Redirect("/");
    }
//-------------------end form---------------------//

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
