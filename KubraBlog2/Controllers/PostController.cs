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




        public async Task<IActionResult> Search(string q)
        {


            var model = await _service.GetAllAsync(p=>p.Name.Contains(q));


            if(model.Count<1)
            {
                ViewData["arama"] = "Sonuç bulunamadı.";



            }

            else { return View(model); }

            return View();
        }

    }
}
