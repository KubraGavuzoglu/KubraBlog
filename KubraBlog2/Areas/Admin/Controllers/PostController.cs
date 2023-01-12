using KubraBlog.WebUI.Utils;
using KubraBlog2.Entities;
using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KubraBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IService<Post> _service;
        private readonly IService<Category> _serviceCategory;
       

        public PostController(IService<Post> service, IService<Category> serviceCategory)
        {
            _service = service;
            _serviceCategory = serviceCategory;
           
        }



        // GET: PostController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();

            return View(model);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");


            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Post post , IFormFile? Image)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    //if (Image is not null)
                    //{
                    //    string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                    //using var stream = new FileStream(klasor, FileMode.Create);
                   // await Image.CopyToAsync(stream);
                   // post.Image = Image.FileName;

                    //}





                    if(Image is not null) post.Image= await FileHelper.FileLoaderAsync(Image);




                    await _service.AddAsync(post);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }

                ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");


            }


            return View(post);
        }

        // GET: PostController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");

            return View(model);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Image is not null) post.Image = await FileHelper.FileLoaderAsync(Image, filePath : "/wwwroot/Img/");




                     _service.Update(post);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }

                ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");


            }


            return View(post);
        }

        // GET: PostController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)

        {
            var model=await _service.FindAsync(id);

            return View(model);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post post)
        {
            try
            {
                _service.Delete(post);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
