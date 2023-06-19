using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EFLectures.Models;
using Microsoft.AspNetCore.Identity;

namespace EFLectures.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

//index route
[HttpGet("")]
public IActionResult Index()
{
    //if statement will make the nav "Home" button go to our home page when logged in, instead of the login/reg page
    if(HttpContext.Session.GetInt32("UUID") != null)
    {
        return RedirectToAction("AllPosts", "Post");
    }
    return View("Index");
}


//register form route
[HttpPost("register")]
public IActionResult Register(User newUser)
{
    if(!ModelState.IsValid)
    {
        return Index(); //this only works because we did NOT default the View("Index");, default example is View();
    }
//hashing users password for our db
    PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
    newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

    db.Users.Add(newUser);
    db.SaveChanges();

    HttpContext.Session.SetInt32("UUID", newUser.UserId);
    return RedirectToAction("AllPosts", "Post");
} 


//login form route
[HttpPost("login")]
public IActionResult Login(LoginUser loginUser)
{
        if (!ModelState.IsValid)
        {
            return Index();
        }

        User? dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if(pwCompareResult == 0)
        {
            // normally dont be specific with errors, only for lecture
            // unspecified example "invalid email/password combination"
            // malicious users like specific errors
            ModelState.AddModelError("LoginPassword", "invalid password");
            return Index();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("AllPosts", "Post");
}


[HttpPost("logout")]
public IActionResult Logout()
{
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
}

}