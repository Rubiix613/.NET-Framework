using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //throw new Exception();
            return View();
        }

        public IActionResult SongForm() => View();

        //[HttpPost]
        public IActionResult Sing()
        {
            return View();
        }

        public IActionResult CreatePerson() => View();

        //[HttpPost]
        //public IActionResult DisplayPerson(Person person)
        //{
        //    // you will complete this
        //}
        public IActionResult Error()
        {
            return View();
        }
    }
}

