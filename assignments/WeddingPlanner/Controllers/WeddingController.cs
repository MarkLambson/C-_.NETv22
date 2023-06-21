using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers; //<--- change to current namespace

[SessionCheck] //<--- session check entire controller
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext db; //<--- change to db

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        db = context; //<--- change to db
    }
// GET TO WORK BELOW :)---------------------------------------------------------------------------------------------------------------------//


    // VIEW ALL WEDDINGS
    [HttpGet("weddings")]
    public IActionResult Index()
    {
        List<Wedding> allWeddings = db.Weddings.Include(wedding => wedding.AllGuests).ToList();
        return View("AllWeddings", allWeddings);
    }


    // NEW WEDDING VIEW
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View("NewWedding");
    }


    // CREATE NEW WEDDING
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            return View("NewWedding");
        }

        newWedding.UserId = (int)HttpContext.Session.GetInt32("UUID");

        db.Weddings.Add(newWedding);
        db.SaveChanges();

        return RedirectToAction("Index");
    }


    // ONE WEDDING VIEW
    [HttpGet("weddings/{id}")]
    public IActionResult ViewWedding(int id)
    {
        Wedding? wedding = db.Weddings.Include(wedding => wedding.AllGuests).ThenInclude(guest => guest.User)
        .FirstOrDefault(wedding => wedding.WeddingId == id);

        if (wedding == null)
        {
            return RedirectToAction("Index");
        }

        return View("ViewWedding", wedding);
    }


    // RSVP (like) could combine with unrsvp as well
    [HttpPost("weddings/{id}")]
    public IActionResult UpdateGuests(int id)
    {
        Guest newGuest = new Guest()
        {
            UserId = HttpContext.Session.GetInt32("UUID"),
            WeddingId = id
        };

        db.Guests.Add(newGuest);
        db.SaveChanges();

        return RedirectToAction("Index");
    }


    // UN-RSVP (remove like)
    [HttpPost("weddings/{id}/unrsvp")]
    public IActionResult UnRSVP(int id)
    {
        Guest? newGuest = db.Guests.FirstOrDefault(guest => guest.UserId == HttpContext.Session.GetInt32("UUID") && guest.WeddingId == id);

        if (newGuest != null)
        {
            db.Guests.Remove(newGuest);
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }


    // DELETE
    [HttpPost("weddings/{id}/destroy")]
    public IActionResult Delete(int id)
    {
        Wedding wedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == id);

        if (wedding != null && wedding.UserId == HttpContext.Session.GetInt32("UUID"))
        {
            db.Weddings.Remove(wedding);
            db.SaveChanges();
        }

        return RedirectToAction("Index");
    }


    // EDIT VIEW (not using for WeddingPlanner, for future reference)
    [HttpGet("weddings/{id}/edit")]
    public IActionResult EditWedding(int id)
    {
        Wedding? OneWedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == id);
        return View("EditWedding", OneWedding);
    }


    // UPDATE (not using for WeddingPlanner, for future reference)
    [HttpPost("weddings/{id}/update")]
    public IActionResult UpdateWedding(Wedding newWedding, int id)
    {
        Wedding? OldWedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == id);
        if(ModelState.IsValid)
        {
            OldWedding.WedderOne = newWedding.WedderOne;
            OldWedding.WedderTwo = newWedding.WedderTwo;
            OldWedding.Date = newWedding.Date;
            OldWedding.Address = newWedding.Address;
            OldWedding.UpdatedAt = newWedding.UpdatedAt;

            db.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View("EditWedding", OldWedding);
        }
    }

//------------------------------------------------------------------------------------------------------------------------------------------------//


    // PRIVACY
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


    // SESSION CHECK ATTRIBUTE (only needs to be on 1 controller)
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find session, keep int? because session could be null
        int? userId = context.HttpContext.Session.GetInt32("UUID");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index or Login if null
            // "User" here is referring to "UserController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}