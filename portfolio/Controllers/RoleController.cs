using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class RoleController : Controller
    {
        public readonly IRoleService<Role> _roleService;
        public RoleController(IRoleService<Role> roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            IEnumerable<Role> roles = _roleService.GetAll();
            View(roles);
            return View();
        }
        public IActionResult Details(int id)
        {
            var role = _roleService.GetById(id);
            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public IActionResult Delete(int id)
        {
            var role = _roleService.GetById(id);

            return View(role);
        }

        [HttpPost]
        public IActionResult Delete(Role role)
        {
            _roleService.Delete(role.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var role = _roleService.GetById(id);
            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        private bool RoleExists(int id)
        {
            return _roleService.EntityExists(id);
        }
    }
}
