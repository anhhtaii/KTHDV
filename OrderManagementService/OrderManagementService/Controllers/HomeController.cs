using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // Tìm kiếm View Index.cshtml trong Views/Home
    }
}
