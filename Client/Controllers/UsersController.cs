using API.Models;
using API.ViewModels;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersRepository repository;

        public UsersController(UsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await repository.Login(login);
            if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", result.Data);

                // Cek jika usercode mengandung huruf "ADM"
                if (login.UserCode.Contains("ADM"))
                {
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Users/Login");
        }

        public async Task<IActionResult> Index()
        {
            //localhost/university/
            var Results = await repository.Get();
            var user = new List<Users>();

            if (Results != null)
            {
                user = Results.Data.ToList();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users user)
        {

            var result = await repository.Post(user);
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
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            //localhost/university/
            var Results = await repository.Get(id);
            //var universities = new University();

            //if (Results != null)
            //{
            //    universities = Results.Data;
            //}

            return View(Results.Data);
        }
    }

}
