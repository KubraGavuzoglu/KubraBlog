﻿using KubraBlog2.Entities;
using KubraBlog2.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KubraBlog.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly IService<Category> _service;

        public Categories(IService<Category> service)
        {
            _service = service;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {

            return View(await _service.GetAllAsync());

        }
    }
}
