using KubraBlog2.Entities;
using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class UserController : Controller
    {
        private readonly IService<User> _service;

        public UserController(IService<User> service)
        {
            _service = service;
        }





        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(User user)
        {
            if(ModelState.IsValid)
            {

                try
                {
                    await _service.AddAsync(user);
                    await _service.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu.");
                    
                }



            }

            return View(user);


        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _service.Update(user);
                    await _service.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                   
                }
            }

            return View(user);

        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {

            var model = await _service.FindAsync(id);


            return View(model);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, User user)
        {
            try
            {
                _service.Delete(user);
               await _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }

            return View();
        }
    }
}
