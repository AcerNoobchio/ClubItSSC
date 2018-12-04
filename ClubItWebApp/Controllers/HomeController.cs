using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClubItWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using ClubItWebApp.Data;

namespace ClubItWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IClubItRepository _repo;
        public HomeController(IClubItRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var user = _repo.ReadApplicationUser(User.Identity.Name);
            var userId = _repo.ReadApplicationUser(user.User.Id);
            if (user.HasRole("SuperAdmin"))
            {
                return RedirectToAction("About", "Home");
            }
            else if (user.HasRole("ClubAdmin"))
            {
                return RedirectToAction("Contact", "Home");
            }
            else if(user.HasRole("StudentUser"))
            {
                return RedirectToAction("ClubFeed", "Home");
            }
            return View();
        }

        public IActionResult ClubFeed()
        {
            var model = _repo.ReadEvents();
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
