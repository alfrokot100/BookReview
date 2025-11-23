using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BookReview.MVC.Models;

namespace BookReview.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _client;

        public AccountController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("BookApi");
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var resp = await _client.PostAsJsonAsync("api/user/register", new
            {
                name = model.Name,
                email = model.Email,
                password = model.Password
            });

            if (!resp.IsSuccessStatusCode)
            {
                ViewBag.Error = await resp.Content.ReadAsStringAsync();
                return View(model);
            }

            return RedirectToAction("Login");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var resp = await _client.PostAsJsonAsync("api/user/login", new
            {
                email = model.Email,
                password = model.Password
            });

            if (!resp.IsSuccessStatusCode)
            {
                ViewBag.Error = await resp.Content.ReadAsStringAsync();
                return View(model);
            }

            var user = await resp.Content.ReadFromJsonAsync<UserInfo>();
            TempData["CurrentUserName"] = user?.name;

            return RedirectToAction("Index", "Home");
        }

        private class UserInfo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
        }
    }
}
