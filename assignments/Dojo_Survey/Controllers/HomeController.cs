using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;

namespace Dojo_Survey.Controllers;
//namespace after project name

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
    public IActionResult SurveySave(Survey newSurvey)
    {
        //checking to see if modelstate is valid
        if (!ModelState.IsValid)
        {
            //returns index view with validation msgs, validation msgs only persist once which is why they need a View
            return View("Index");
        }
        //if valid return the view for the results page with the new "newSurvey" data
        return View("result", newSurvey);
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