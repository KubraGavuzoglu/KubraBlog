using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
