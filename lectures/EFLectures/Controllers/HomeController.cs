using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFLectures.Models;

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

//read all
[HttpGet("")]
    public IActionResult Index()
    {
        List<Post> allPosts = db.Posts.ToList();
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
        if(!ModelState.IsValid)
        {
            //send user back to form to see validations and fix them
            return View("New");
        }
        db.Posts.Add(newPost);
        //db doesnt run until SaveChanges()
        db.SaveChanges();
        // RedirectToAction looks at name of function, not URL
        return RedirectToAction("Index");
    }

//read one
    [HttpGet("posts/{id}")]
    public IActionResult ViewPost(int id) 
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == id);

        if (post == null)
        {
            return RedirectToAction("Index");
        }

        return View("Details", post);
    }

//delete
    [HttpPost("posts/{postId}/delete")]
    public IActionResult DeletePost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);
        if(post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

//update
    [HttpGet("posts/{postId}/edit")]
    public IActionResult EditPost(int postId)
    {
        Post? post = db.Posts.FirstOrDefault(post => post.PostId == postId);

        if(post == null)
        {
            return RedirectToAction("Index");
        }
        return View("Edit", post);
    }

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
            return RedirectToAction("Index");
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
