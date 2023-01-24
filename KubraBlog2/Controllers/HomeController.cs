using KubraBlog2.Entities;
using KubraBlog2.Models;
using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KubraBlog2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Post> _service;

        public HomeController(IService<Post> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model= await _service.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}