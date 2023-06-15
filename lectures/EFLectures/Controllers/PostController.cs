using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EFLectures.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EFLectures.Controllers;

[SessionCheck]

public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private MyContext db;

    public PostController(ILogger<PostController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    //read all
    [HttpGet("/posts")]
    public IActionResult AllPosts()
    {
        List<Post> allPosts = db.Posts.Include(post => post.Author).ToList();
        return View("AllPosts", allPosts);
    }



    [HttpGet("posts/new")]
    public IActionResult NewPost()
    {
        return View("New");
    }



    //keep urls lowercase, helps with debugging
    //create
    [HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (!ModelState.IsValid)
        {
            //send user back to form to see validations and fix them
            return View("New");
        }

        newPost.UserId = (int)HttpContext.Session.GetInt32("UUID");  //ignore this warning, we have checked with sessioncheck

        db.Posts.Add(newPost);
        //db doesnt run until SaveChanges()
        db.SaveChanges();
        // RedirectToAction looks at name of function, not URL
        return RedirectToAction("AllPosts");
    }


    //read one
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
    [HttpPost("posts/{postId}/delete")]
    public IActionResult DeletePost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);
        if (post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        return RedirectToAction("AllPosts");
    }


    //update
    [HttpGet("posts/{postId}/edit")]
    public IActionResult EditPost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if (post == null)
        {
            return RedirectToAction("AllPosts");
        }
        return View("Edit", post);
    }



    [HttpPost("posts/{postId}/edit")]
    public IActionResult UpdatePost(int postId, Post updatedPost)
    {
        if (!ModelState.IsValid)
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