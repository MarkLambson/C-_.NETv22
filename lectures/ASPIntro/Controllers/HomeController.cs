using Microsoft.AspNetCore.Mvc;
namespace ASPIntro.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
//  [HttpGet("")] <--- combines both the above lines into one, personal preference

//how we handle incoming user request
    public ViewResult Index()
    {
        //how we respond to user request
        return View("Index");
        //this View will look for the name of the file we put as the argument, "Index"
    }

    [HttpGet]
    [Route("videos")]
    public ViewResult Videos()
    {
        ViewBag.Videos = new List<string>()
        {
            "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        };
        //viewbag doesnt care about data type you are passing in, 
        //so we don't know what type is in there just looking at it :)
        return View("Videos");
    }
}