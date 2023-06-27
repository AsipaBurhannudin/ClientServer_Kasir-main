using API.Models;
using Client.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace Client.Controllers
{
    [Authorize(Policy = "ManagerOnly")]
    public class ManagerController : Controller
    {
        private readonly UsersRepository repository;

        public ManagerController(UsersRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Item()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users users)
        {
            var result = await repository.Post(users);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil masuk";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }

            return View();
        }

        public async Task<IActionResult> List()
        {
            var results = await repository.Get();
            var users = results?.Data ?? new List<Users>();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var result = await repository.Get(id);
            var users = result.Data;

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Put(users);
                if (result != null && result.Code == 200)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (result != null && result.Code == 409)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await repository.Get(id);
            var users = new Users();
            if (result.Data?.user_code is null)
            {
                return View(users);
            }
            else
            {
                users.user_code = result.Data.user_code;
                users.password = result.Data.password;
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await repository.Get(id);
            var users = result?.Data;

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var result = await repository.Delete(id);
            if (result.Code == 200)
            {
                TempData["Success"] = "Data berhasil dihapus";
                return RedirectToAction(nameof(Index));
            }
            else if (result.Code == 404)
            {
                ModelState.AddModelError(string.Empty, result.Message);
            }

            var users = await repository.Get(id);
            return View("Delete", users?.Data);
        }
    }
}