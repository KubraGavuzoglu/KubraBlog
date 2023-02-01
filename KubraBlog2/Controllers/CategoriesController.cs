using KubraBlog2.Entities;
using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = await  _service.GetCategoryByProducts(id);


            return View(model);
        }
    }
}
