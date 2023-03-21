using CookieDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        private static int _number;

        public IActionResult Index()
        {
            _number++;
            return View(new CounterViewModel
            {
                Number = _number
            });
        }
    }
}