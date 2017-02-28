using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using activityCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace activityCenter.Controllers{
    public class ActivitiesController : Controller{

        private activityCenterContext _context;
        public ActivitiesController(activityCenterContext context){
            _context = context;
        }




        // GET: /NewActivity/
        [HttpGet]
        [Route("NewActivity")]
        public IActionResult NewActivity(Activity activity){
            ViewBag.Errors = new List<User>();
            return View("New");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Activity activity){
            if(ModelState.IsValid){
                System.Console.WriteLine("MODEL STATE IS VALID");
                Activity NewActivity = new Activity{
                    Title = activity.Title,
                    Description = activity.Description,
                    ActivityDate = activity.ActivityDate,
                    ActivityTime = activity.ActivityTime,
                    DurationVal = activity.DurationVal,
                    DurationUnit = activity.DurationUnit,
                    UserId = (int)HttpContext.Session.GetInt32("CurrUserId")
                };
                _context.Add(NewActivity);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Users");
            } else {
                ViewBag.Errors = ModelState.Values;
                return View("New");
            }
        }




    }
}
