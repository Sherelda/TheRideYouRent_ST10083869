using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRideYouRent_ST10083869.Models;

namespace TheRideYouRent_ST10083869.Controllers
{
    public class LateController : Controller
    {
        public IActionResult Index()
        {
            List<string> ops = new List<string> { "*" };
            ViewBag.ops = new List<string>(ops);
            return View();
        }

        [HttpPost]
        public IActionResult Index(string LateDays, string Fee, string operations)
        {
            int Fine = 0;

            switch (operations)
            {
                case "*":
                    Fine = Convert.ToInt32(LateDays) * Convert.ToInt32(Fee);
                    break;
                default:
                    break;
            }

            ViewBag.Fine = Fine;

            Late l = new Late(Convert.ToInt32(Fee), Convert.ToInt32(LateDays), Fine);

            List<string> ops = new List<string> { "*" };
            ViewBag.ops = new List<string>(ops);
            return View();
        }

    }

    }
