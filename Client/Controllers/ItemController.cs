using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
            private readonly ItemRepository repository;

            public ItemController(ItemRepository repository)
            {
                this.repository = repository;
            }

            public async Task<IActionResult> Index()
            {
                var results = await repository.Get();
                var items = results?.Data ?? new List<Item>();

                return View(items);
            }

            [HttpGet]
            public async Task<IActionResult> Details(string id)
            {
                var result = await repository.Get(id);
                var items = result.Data;

                return View(items);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Item item)
            {
                var result = await repository.Post(item);
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

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Item item)
            {
                if (ModelState.IsValid)
                {
                    var result = await repository.Put(item);
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
                var item = new Item();
                if (result.Data?.item_code is null)
                {
                    return View(item);
                }
                else
                {
                    item.item_code = result.Data.item_code;
                    item.item_name = result.Data.item_name;
                }

                return View(item);
            }

            [HttpGet]
            public async Task<IActionResult> Delete(string id)
            {
                var result = await repository.Get(id);
                var item = result?.Data;

                return View(item);
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

                var item = await repository.Get(id);
                return View("Delete", item?.Data);
            }

        }
    }
