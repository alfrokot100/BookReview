using BookReview.MVC.Models;
using BookReview.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReview.MVC.Controllers
{
    public class AIReviewController : Controller
    {
        private readonly AiService _aiService;

        public AIReviewController(AiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
			return View(new AiViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Index(AiViewModel vm)
		{
			if (!ModelState.IsValid)
				return View(vm);

			var aiText = await _aiService.GenerateReviewAsync(vm);

			vm.AIText = aiText; // Lägg in AI svaret i modellen

			return View(vm);
		}

		public IActionResult Result(AiViewModel vm)
		{
			return View(vm);
		}
	}
}
