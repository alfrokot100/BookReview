using Microsoft.AspNetCore.Mvc;

namespace BookReview.MVC.Controllers
{
    public class AIReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
