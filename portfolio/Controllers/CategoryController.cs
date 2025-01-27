﻿using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CategoryController : Controller
    {
        public readonly IService<Category> _categoryService;
        public CategoryController(IService<Category> categoryService) 
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryService.GetAll();
            View(categories);
            return View();
        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category =  _categoryService.GetById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _categoryService.Delete(category.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]

        public IActionResult Edit( int id,Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);


        }

        private bool CategoryExists(int id)
        {
            return _categoryService.EntityExists(id);
        }
    }
}
