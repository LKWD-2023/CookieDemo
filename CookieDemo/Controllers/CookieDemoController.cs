using CookieDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookieDemo.Controllers
{
    public class CookieDemoController : Controller
    {
        public IActionResult Index()
        {
            var requestCookieValue = Request.Cookies["last-visit"];
            var hasBeenHere = requestCookieValue != null;

            var vm = new CookieDemoViewModel
            {
                HasBeenHere = hasBeenHere
            };

            if (hasBeenHere)
            {
                vm.LastVisit = DateTime.Parse(requestCookieValue);
            }

            Response.Cookies.Append("last-visit", DateTime.Now.ToString());
            return View(vm);
        }

        public IActionResult Counter()
        {
            string cookieValue = Request.Cookies["number"];

            int number = 1;
            if (cookieValue != null)
            {
                number = int.Parse(cookieValue);
            }

            Response.Cookies.Append("number", $"{number + 1}");

            var vm = new CounterViewModel
            {
                Number = number
            };

            return View(vm);
        }
    }
}
