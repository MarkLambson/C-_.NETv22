using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; //for the last thing from Spencer's lecture, can be used to make a SelectListItem in our Controller
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

//----------work in here-----------//
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

    [HttpPost("addPetSession")]
    public IActionResult CreateWithSession(Pet newPet)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        //key value pairs                key         value
        HttpContext.Session.SetString("PetName", newPet.Name);
        HttpContext.Session.SetString("PetType", newPet.Type);
        HttpContext.Session.SetInt32("PetAge", newPet.Age);

        string? sessionName = HttpContext.Session.GetString("PetName");
        string? sessionType = HttpContext.Session.GetString("PetType");
        int? sessionAge = HttpContext.Session.GetInt32("PetAge");

        Console.WriteLine($"Pet Name is {sessionName}, Pet Age is {sessionAge}");

        return RedirectToAction("Success");
    }

    [HttpGet("success")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [HttpPost("clearSession")]
    public IActionResult ClearSession()
    {
    // HttpContext.Session.Remove(); use to remove one item but you need to pass it as an argument

        HttpContext.Session.Clear();
        //redirect to action still redirects the user
        //but you need to pass the function name rather than the URL
        return RedirectToAction("Index");
    }

//-------------------work in here---------------------//

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
