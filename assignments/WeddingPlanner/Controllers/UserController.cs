using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext db;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }
// GET TO WORK BELOW :)---------------------------------------------------------------------------------------------------------------------//


    // INDEX
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }


    // REGISTER
    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid)//<-- check form validations
        {
            return Index();
        }

        PasswordHasher<User> hashbrowns = new PasswordHasher<User>();
        newUser.Password = hashbrowns.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges(); //<-- must have to save changes to db

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("FirstName", newUser.FirstName);
        return RedirectToAction("Index", "Wedding");
    }


    // LOGIN
    [HttpPost("login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid)//<-- check form validations
        {
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        PasswordHasher<LoginUser> hashbrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashbrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "invalid email or password...");
            return Index();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("FirstName", dbUser.FirstName);
        return RedirectToAction("Index", "Wedding");
    }


    // LOGOUT
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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



// Session Check (do not need if on another controller)
// public class SessionCheckAttribute : ActionFilterAttribute
// {
//     public override void OnActionExecuting(ActionExecutingContext context)
//     {
//         // Find the session, but remember it may be null so we need int?
//         int? userId = context.HttpContext.Session.GetInt32("UUID");
//         // Check to see if we got back null
//         if (userId == null)
//         {
//             // Redirect to the Index page if there was nothing in session
//             // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
//             context.Result = new RedirectToActionResult("Index", "User", null);
//         }
//     }
// }
