using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using Microsoft.AspNetCore.Http;
using Lab5.Services;
using Lab5.ViewModels;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        // Shows default view and reads cookie if it exists.
        public IActionResult ClearCookie(string key)
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request,
                                                            Response);
            cookieHelper.Remove(key);
            return RedirectToAction("Index", "Home");
        }

        // Let’s user store value in cookie.
        [HttpPost]
        public ActionResult Index(SiteUserVM siteUser)
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request,
                                                            Response);
            const int DAYS_TO_EXPIRE = 1;
            cookieHelper.Set("firstName", siteUser.FirstName, DAYS_TO_EXPIRE);
            cookieHelper.Set("lastName", siteUser.LastName, DAYS_TO_EXPIRE);
            // Redirect to GET method so cookie is read.
            return RedirectToAction("Index", "Home");
        }

        // Shows default view and reads cookie if it exists.
        [HttpGet]
        public IActionResult Index()
        {
            CookieHelper cookieHelper = new CookieHelper(_httpContextAccessor, Request,
                                                            Response);
            string firstName = cookieHelper.Get("FirstName");
            string lastName = cookieHelper.Get("LastName");
            if (firstName != null)
            {
                ViewBag.UserName = firstName; // The ViewBag uses the ViewData dictionary
                                              // to send additional content to the view.
                                              // You can conveniently create as many 
                                              // ViewBag properties as desired as long as
                                              // each name is unique.
            }
            if (lastName != null)
            {
                ViewBag.UserLastName = lastName;
            }
            return View();
        }

    }
}
