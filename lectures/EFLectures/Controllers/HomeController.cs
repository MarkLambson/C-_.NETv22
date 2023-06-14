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
    return RedirectToAction("AllPosts");
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
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("AllPosts");
}


[HttpPost("logout")]
public IActionResult Logout()
{
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
}


    //read all
    [SessionCheck]
    [HttpGet("/posts")]
    public IActionResult AllPosts()
    {
        List<Post> allPosts = db.Posts.ToList();
        return View("AllPosts", allPosts);
    }



    [SessionCheck]
    [HttpGet("posts/new")]
    public IActionResult NewPost()
    {
        return View("New");
    }



    //keep urls lowercase, helps with debugging
    //create
    [SessionCheck]
    [HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if(!ModelState.IsValid)
        {
            //send user back to form to see validations and fix them
            return View("New");
        }
        db.Posts.Add(newPost);
        //db doesnt run until SaveChanges()
        db.SaveChanges();
        // RedirectToAction looks at name of function, not URL
        return RedirectToAction("AllPosts");
    }


    //read one
    [SessionCheck]
    [HttpGet("posts/{id}")]
    public IActionResult ViewPost(int id) 
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == id);

        if (post == null)
        {
            return RedirectToAction("AllPosts");
        }

        return View("Details", post);
    }


    //delete
    [SessionCheck]
    [HttpPost("posts/{postId}/delete")]
    public IActionResult DeletePost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);
        if(post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        return RedirectToAction("AllPosts");
    }


    //update
    [SessionCheck]
    [HttpGet("posts/{postId}/edit")]
    public IActionResult EditPost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if(post == null)
        {
            return RedirectToAction("AllPosts");
        }
        return View("Edit", post);
    }



    [SessionCheck]
    [HttpPost("posts/{postId}/edit")]
    public IActionResult UpdatePost(int postId, Post updatedPost)
    {
        if(!ModelState.IsValid)
        {
            return EditPost(postId);
        }

        Post? dbPost = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (dbPost == null)
        {
            return RedirectToAction("AllPosts");
        }

        dbPost.Topic = updatedPost.Topic;
        dbPost.Body = updatedPost.Body;
        dbPost.ImgUrl = updatedPost.ImgUrl;
        dbPost.UpdatedAt = DateTime.Now;

        // db.Posts.Update(dbPost);  <--- don't need this, will work with just .SaveChanges();
        db.SaveChanges();

        return RedirectToAction("ViewPost", new { id = dbPost.PostId });
    }



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



// Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UUID");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}