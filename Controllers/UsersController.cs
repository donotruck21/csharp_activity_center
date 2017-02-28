using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using activityCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace activityCenter.Controllers{
    public class UsersController : Controller{

        private activityCenterContext _context;
        public UsersController(activityCenterContext context){
            _context = context;
        }




        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View();
        }

        // POSt: /Home/
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(){
            System.Console.WriteLine("in register route!!");
            System.Console.WriteLine("in register route!!");
            System.Console.WriteLine("in register route!!");
            return RedirectToAction("Index");
        }





    }
}
