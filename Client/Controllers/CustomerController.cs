using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
            private readonly CustomerRepository repository;

            public CustomerController(CustomerRepository repository)
            {
                this.repository = repository;
            }

            public async Task<IActionResult> Index()
            {
                var results = await repository.Get();
                var items = results?.Data ?? new List<Customer>();

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
            public async Task<IActionResult> Create(Customer customer)
            {
                var result = await repository.Post(customer);
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
            public async Task<IActionResult> Edit(Customer customer)
            {
                if (ModelState.IsValid)
                {
                    var result = await repository.Put(customer);
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
                var customer = new Customer();
                if (result.Data?.customer_id is null)
                {
                    return View(customer);
                }
                else
                {
                    customer.customer_id = result.Data.customer_id;
                customer.customer_name = result.Data.customer_name;
                }

                return View(customer);
            }

            [HttpGet]
            public async Task<IActionResult> Delete(string id)
            {
                var result = await repository.Get(id);
                var customer = result?.Data;

                return View(customer);
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

                var customer = await repository.Get(id);
                return View("Delete", customer?.Data);
            }

        }
    }
