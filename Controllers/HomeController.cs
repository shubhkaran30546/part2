using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using part2.Models;

namespace part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PictureService _pictureService;

        // Modify the constructor to accept PictureService as a parameter
        public HomeController(ILogger<HomeController> logger, PictureService pictureService)
        {
            _logger = logger;
            _pictureService = pictureService;
        }

        public IActionResult Index()
        {
            var pictures = _pictureService.GetPictures();
            if (pictures == null || !pictures.Any())
            {
                // Log or output message
                Console.WriteLine("No pictures available.");
                return View(new List<Picture>());
            }
            return View(pictures);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
