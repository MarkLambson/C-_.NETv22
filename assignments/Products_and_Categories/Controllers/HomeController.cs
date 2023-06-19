using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext db;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }


// Product Routes-------------------------------------------------------------------------------------------------------------------------------------------------------//
    [HttpGet("")]
    public IActionResult Products()
    {
        ViewBag.AllProducts = db.Products.ToList();
        return View();
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            db.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        ViewBag.AllProducts = db.Products.ToList();
        return View("Products");
    }

    [HttpGet("products/{ProductId}")]
    public IActionResult AddToProduct(int ProductId)
    {
        ViewBag.OneProduct = db.Products.Include(assoc => assoc.AssoCategories).ThenInclude(assoc => assoc.Category).FirstOrDefault(prod => prod.ProductId == ProductId);

        ViewBag.FilteredCategories = db.Categories.Include(cat => cat.AssoProducts).Where(cat => cat.AssoProducts.All(assoc => assoc.ProductId != ProductId)).ToList();
        return View();
    }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


    // Category Routes-------------------------------------------------------------------------------------------------------------------------------------------------------//
    [HttpGet("categories")]
    public IActionResult Categories()
    {
        ViewBag.AllCategories = db.Categories.ToList();
        return View();
    }

    [HttpPost("Categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            db.Add(newCategory);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }
        ViewBag.AllCategories = db.Categories.ToList();
        return View("Categories");
    }

    [HttpGet("categories/{CategoryId}")]
    public IActionResult AddToCategory(int CategoryId)
    {
        ViewBag.OneCategory = db.Categories.Include(assoc => assoc.AssoProducts).ThenInclude(assoc => assoc.Product).FirstOrDefault(cat => cat.CategoryId == CategoryId);

        ViewBag.FilteredProducts = db.Products.Include(prod => prod.AssoCategories).Where(prod => prod.AssoCategories.All(assoc => assoc.CategoryId != CategoryId)).ToList();
        return View();
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


    // Association Routes-------------------------------------------------------------------------------------------------------------------------------------------------------//
    [HttpPost("association/create/toproduct")]
    public IActionResult CreateAssociationToProduct(Association newAssoc)
    {
        if (newAssoc?.ProductId != null && newAssoc?.CategoryId != null)
        {
            db.Add(newAssoc);
            db.SaveChanges();
            ViewBag.AllProducts = db.Products.ToList();
            return RedirectToAction("AddToProduct", new { newAssoc.ProductId });
        }
        return View("AddToProduct");
    }

    [HttpPost("association/create/tocategory")]
    public IActionResult CreateAssociationToCategory(Association newAssoc)
    {
        if (newAssoc?.ProductId != null && newAssoc?.CategoryId != null)
        {
            db.Add(newAssoc);
            db.SaveChanges();
            ViewBag.AllCategories = db.Categories.ToList();
            return RedirectToAction("AddToCategory", new { newAssoc.CategoryId });
        }
        return View("AddToCategory");
    }

//--------------------BONUS-----------------------//
    [HttpPost("assocciation/{AssocId}/destroy")]
    public IActionResult DeleteAssociation(int AssocId, string navRoute)
    {
        Association? AssocToDelete = db.Associations.SingleOrDefault(assoc => assoc.AssociationId == AssocId);
        db.Associations.Remove(AssocToDelete);
        db.SaveChanges();
        if (navRoute == "ToProduct")
        {
            return RedirectToAction("AddToProduct", new { AssocToDelete.ProductId });
        }
        else
        {
            return RedirectToAction("AddToCategory", new { AssocToDelete.CategoryId });
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
}




    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }