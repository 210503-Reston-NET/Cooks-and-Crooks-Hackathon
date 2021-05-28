using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RRWebUI.Models;
using System.Diagnostics;
using RRBL;
using RRModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace RRWebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRestaurantBL _restaurantBL;
        private UserManager<Customer> _userManager;

        public HomeController(ILogger<HomeController> logger, IRestaurantBL restaurantBL, UserManager<Customer> userManager)
        {
            _logger = logger;
            _restaurantBL = restaurantBL;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Customer user = await _userManager.FindByEmailAsync(User.Identity.Name);
            user.City = "Portland";
            user.State = "OR";
            List<RestaurantVM> recommendation = _restaurantBL.GetRecommendation(user).Select(resto => new RestaurantVM(resto)).ToList();

            return View(recommendation);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}