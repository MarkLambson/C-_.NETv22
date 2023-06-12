using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomValidations.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")] //displays our form
    public IActionResult Index()
    {
        ViewBag.Choices =  new List<SelectListItem>(){
            new SelectListItem("pizza","pizza"),
            new SelectListItem("sushi","sushi"),
            new SelectListItem("cake","cake")
        };
        return View();
    }

    [HttpPost("process")] //process our form
    public IActionResult Process(MyForm formData)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Results", formData);
        }
        return View("Index");
    }

    [HttpGet("results")]
    public ViewResult Results(MyForm formData) 
    {
        return View(formData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
