﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.Areas.Admin.Controllers
{

    [Area("Admin"),Authorize]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {
            return View();
        }
    }
}
