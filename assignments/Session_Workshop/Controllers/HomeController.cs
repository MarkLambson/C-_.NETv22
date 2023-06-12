using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

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

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

//so malicious users cant use "/dashboard"
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

    //----------------------work below---------------------------//

    [HttpGet("/Dashboard")]
    public IActionResult Dashboard()
    {
        string? Name = HttpContext.Session.GetString("UserName");
        if (!(Name == null))
        {
            return View("Dashboard");
        }
        return Redirect("/");
    }

    [HttpPost("Username")]
    public IActionResult UserName(string name)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        if (name != null)
        {
            HttpContext.Session.SetString("UserName", name);
            return Redirect("Dashboard");
        }
        return Redirect("/");
    }

    [HttpPost("logout")]
    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        HttpContext.Session.SetInt32("Num", 22);
        return Redirect("/");
    }

    [HttpPost("increase")]
    public IActionResult Increase(string num)
    {
        if (num == "1")
        {
            int? newNum = HttpContext.Session.GetInt32("Num");
            if (newNum != null) HttpContext.Session.SetInt32("Num", (int)newNum + 1);
            return Redirect("/Dashboard");
        }
        if (num == "-1")
        {
            int? newNum = HttpContext.Session.GetInt32("Num");
            if (newNum != null) HttpContext.Session.SetInt32("Num", (int)newNum - 1);
            return Redirect("/Dashboard");
        }
        if (num == "x2")
        {
            int? newNum = HttpContext.Session.GetInt32("Num");
            if (newNum != null) HttpContext.Session.SetInt32("Num", (int)newNum * 2);
            return Redirect("/Dashboard");
        }
        if (num == "random")
        {
            Random rand = new Random();
            int randNum = rand.Next(1, 11);
            int? newNum = HttpContext.Session.GetInt32("Num");
            if (newNum != null) HttpContext.Session.SetInt32("Num", (int)newNum + randNum);
            return Redirect("/Dashboard");
        }
        return Redirect("/Dashboard");
    }
}
