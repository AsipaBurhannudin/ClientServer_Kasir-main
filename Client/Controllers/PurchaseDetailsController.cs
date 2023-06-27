using API.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Authorize]
    public class PurchaseDetailsController : Controller
    {
            private readonly PurchaseDetailsRepository repository;

            public PurchaseDetailsController(PurchaseDetailsRepository repository)
            {
                this.repository = repository;
            }

            public async Task<IActionResult> Index()
            {
                var results = await repository.Get();
                var purchaseDetails = results?.Data ?? new List<PurchaseDetails>();

                return View(purchaseDetails);
            }

            [HttpGet]
            public async Task<IActionResult> Details(string id)
            {
                var result = await repository.Get(id);
                var purchaseDetails = result.Data;

                return View(purchaseDetails);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(PurchaseDetails purchaseDetails)
            {
                var result = await repository.Post(purchaseDetails);
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
            public async Task<IActionResult> Edit(PurchaseDetails purchaseDetails)
            {
                if (ModelState.IsValid)
                {
                    var result = await repository.Put(purchaseDetails);
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
                var purchaseDetails = new PurchaseDetails();
                if (result.Data?.item_code is null)
                {
                    return View(purchaseDetails);
                }
                else
                {
                    purchaseDetails.purchase_code = result.Data.purchase_code;
                    purchaseDetails.item_code = result.Data.item_code;
                }

                return View(purchaseDetails);
            }

            [HttpGet]
            public async Task<IActionResult> Delete(string id)
            {
                var result = await repository.Get(id);
                var purchaseDetails = result?.Data;

                return View(purchaseDetails);
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

                var purchaseDetails = await repository.Get(id);
                return View("Delete", purchaseDetails?.Data);
            }

        }
    }
