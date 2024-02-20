using EntityFrameworkCore.WebAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.WebAPI.Controllers;
public class HomeController(ApplicationDbContext context) : Controller
{
    public IActionResult Index()
    {
        
        return View();
    }
}
