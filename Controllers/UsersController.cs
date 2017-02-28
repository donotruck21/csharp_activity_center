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
            ViewBag.Errors = new List<User>();
            return View();
        }

        // POSt: /Home/
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                System.Console.WriteLine("MODEL STATE IS VALID!!");
                return RedirectToAction("Index");
            } else {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
        }





    }
}
