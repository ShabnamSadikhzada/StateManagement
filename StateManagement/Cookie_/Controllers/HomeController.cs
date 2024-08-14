using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.VisualBasic;

namespace Cookie_.Controllers;

public class HomeController : Controller
{
    private readonly string COOKIE_NAME = "survey";

    public IActionResult Index()
    {
        var cookie = Request.Cookies[COOKIE_NAME];

        return View(model: cookie, viewName: nameof(Index));
    }

    [HttpPost]
    public IActionResult Index(string survey)
    {
        CookieOptions options = new()
        {
            //Expires = DateTime.Now.AddDays(1)
            //Expires = DateTime.Now.AddMinutes(1)
            Expires = DateTime.Now.AddSeconds(10)
        };

        Response.Cookies.Append(COOKIE_NAME, survey, options);

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Clear()
    {
        Response.Cookies.Append(COOKIE_NAME, "", new()
        {
            Expires = DateTime.Now.AddDays(-1)
        });

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete()
    {
        Response.Cookies.Delete(COOKIE_NAME);
        return RedirectToAction(nameof(Index));
    }
}
