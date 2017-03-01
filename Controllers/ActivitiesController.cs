using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using activityCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // POST: /Activity<ID>/
        [HttpGet]
        [Route("Activity/{ActivityId}")]
        public IActionResult Show(int ActivityId){
            ViewBag.ThisActivity = _context.Activities.Include(activity => activity.User).SingleOrDefault(act => act.ActivityId == ActivityId);
            return View();
        }


        // POST: /Join/
        [HttpPost]
        [Route("Join")]
        public IActionResult Join(int ActivityId){
            User CurrUser = _context.Users.SingleOrDefault( user => user.UserId == HttpContext.Session.GetInt32("CurrUserId") );

            Activity CurrActivity = _context.Activities.SingleOrDefault( act => act.ActivityId == ActivityId );

            JoinedUser AlreadyJoined = _context.JoinedUsers.SingleOrDefault( JU => 
                (JU.ActivityId == CurrActivity.ActivityId) &&
                (JU.UserId == CurrUser.UserId));

            if(AlreadyJoined == null){
                System.Console.WriteLine("NEW JOINING USER");
            } else {
                System.Console.WriteLine("THIS JOIN ALREADY EXISTS");
            }
            
            return RedirectToAction("Dashboard", "Users");
        }




    }
}
