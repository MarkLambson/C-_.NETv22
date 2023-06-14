using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }
//------------------------------------------------------------------------------//


// Index
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.AllDishes = db.Dishes.ToList();
        return View("Index");
    }


// Create a new dish
    [HttpGet("add")]
    public IActionResult Add()
    {
        return View();
    }


// View one dish
    [HttpGet("dishes/{id}")]
    public IActionResult Dish(int id)
    {
        Dish? OneDish = db.Dishes.FirstOrDefault(dish => dish.DishId == id);
        return View(OneDish);
    }


// Edit one dish
    [HttpGet("/edit/{id}")]
    public IActionResult Edit(int id)
    {
        Dish? OneDish = db.Dishes.FirstOrDefault(dish => dish.DishId == id);
        return View(OneDish);
    }


// Create a new dish
    [HttpPost("add")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            db.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Add");
    }


// Edit a dish
    [HttpPost]
    [Route("/edit/{id}")]
    public IActionResult UpdateDish(Dish updateDish, int id)
    {
        Dish? OldDish = db.Dishes.FirstOrDefault(dish => dish.DishId == id);
        if (ModelState.IsValid)
        {
            if (OldDish != null)
            {
                OldDish.Name = updateDish.Name;
                OldDish.Chef = updateDish.Chef;
                OldDish.Tastiness = updateDish.Tastiness;
                OldDish.Calories = updateDish.Calories;
                OldDish.Description = updateDish.Description;
                OldDish.UpdatedAt = DateTime.Now;
                db.SaveChanges();
                return Redirect("/dishes/" + OldDish.DishId);
            }
        }
        return View("Edit");
    }


// Delete a dish
    [HttpPost("/delete/{id}")]
    public IActionResult Delete(int id)
    {
        Dish? DishToDel = db.Dishes.SingleOrDefault(d => d.DishId == id);
        if (DishToDel != null) 
        {
        db.Dishes.Remove(DishToDel);
        db.SaveChanges();
        }
        return RedirectToAction("Index");
    }


    // Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
