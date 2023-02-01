using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model=await _service.FindAsync(id);

            return View(model);
        }

    }
}
