using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
