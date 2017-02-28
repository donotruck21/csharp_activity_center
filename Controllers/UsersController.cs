using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using activityCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            if(HttpContext.Session.GetString("LoginErrors") == null){
                HttpContext.Session.SetString("LoginErrors", "");
            }
            ViewBag.LoginErrors = HttpContext.Session.GetString("LoginErrors");
            return View();
        }

        // POST: /Register/
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model){
            if(ModelState.IsValid){
                System.Console.WriteLine("MODEL STATE IS VALID!!");
                User NewUser = new User{
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                _context.Add(NewUser);
                _context.SaveChanges();
                System.Console.WriteLine($"SUCCESSFULLY ADDED {NewUser.FirstName} {NewUser.LastName}!!");
                

                User CurrUser = _context.Users.Last();
                HttpContext.Session.SetInt32("CurrUserId", CurrUser.UserId);
                return RedirectToAction("Dashboard");
            } else {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
        }

        // POST: /LogIn/
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string PwToCheck){
                var user = _context.Users.SingleOrDefault( userr => userr.Email == email );
                if( user != null && PwToCheck != null){
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(user, user.Password, PwToCheck)){
                        HttpContext.Session.SetInt32("CurrUserId", user.UserId);
                        return RedirectToAction("Dashboard");
                    } else {
                        HttpContext.Session.SetString("LoginErrors", "Invalid Name or Password");
                        return RedirectToAction("Index");
                    }
                } else {
                    HttpContext.Session.SetString("LoginErrors", "Invalid Name or Password");
                    return RedirectToAction("Index");
                }
        }

        // GET: /Dashboard/
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard(){
            System.Console.WriteLine("IN DASHBOARD METHOD!!");
            ViewBag.CurrUser = _context.Users.SingleOrDefault( user => user.UserId == HttpContext.Session.GetInt32("CurrUserId") );
            return View();
        }








        // GET: /Logout/
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



    }
}
