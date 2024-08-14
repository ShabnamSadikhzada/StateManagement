using Microsoft.AspNetCore.Mvc;
using Session_.Models;
using Session_.Services;

namespace Session_.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    static List<Category> categories = new ()
    {
        new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales"},
        new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
        new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
        new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
        new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
        new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
    };


    private const string SessionCategoryKey = "_Category";

    [HttpGet]
    public IActionResult Get()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCategoryKey)))
        {
            HttpContext.Session.Set<List<Category>>(SessionCategoryKey, categories);
        }

        var categoriesList = HttpContext.Session.Get<List<Category>>(SessionCategoryKey);

        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Post(Category category)
    {
        int cId = categories.Select(c => c.CategoryID).Max();
        category.CategoryID = cId + 1;

        categories.Add(category);     
        return Ok(category);
    }
}
