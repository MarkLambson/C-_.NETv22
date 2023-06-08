using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;

namespace Dojo_Survey.Controllers;

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
//work in here------------------------------------------------------------------------------------------//

    [HttpPost("survey")]
    public IActionResult SurveySave(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        // return view to not lose ViewBag info, Redirect will lose the bag
        return View("result");
    }

    [HttpGet("results")]
    public ViewResult Result()
    {
        return View("result");
    }

//^^ work in here -----------------------------------------------------------------------------------------//
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
