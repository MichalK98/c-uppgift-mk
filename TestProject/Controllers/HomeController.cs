using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestProject.Types;

namespace TestProject.Controllers
{
    public class HomeIndexViewModel
    {
        public List<User> Users;
    }

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(new HomeIndexViewModel()
            {
                Users = MemoryDatabase.Items
            });
        }

        [HttpGet("/error")]
        public IActionResult Error()
        {
            return View(new HomeIndexViewModel()
            {
                Users = MemoryDatabase.Items
            });
        }

        [HttpPost("/api/user")]
        public IActionResult Post(string name, string age, string gender, string color)
        {
            if (!string.IsNullOrEmpty(name))
            {
                int number;
                bool success = Int32.TryParse(age, out number);
                if (success)
                {
                    MemoryDatabase.AddItem(new User
                    {
                        Name = name,
                        Age = age,
                        Gender = gender,
                        Color = color
                    });
                    return Redirect("/");
                }
            }
            // <p>Warning</p>
            return Redirect("/error");
        }
    }
}

// TODO:
// mappa till user objekt (int age, kille tjej  (radiobtn), enum? )

// TIPS:
// .net core map post to object