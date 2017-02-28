using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace activityCenter.Models{
    public class MyDateAttribute : ValidationAttribute{
        public override bool IsValid(object value){
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }


    public class Activity : BaseEntity{
        public int ActivityId { get; set; }
        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [MyDate(ErrorMessage = "Date must be in the future")]
        public DateTime ActivityDate { get; set; }

        [Required(ErrorMessage = "Please Input Activity Time")]
        public DateTime ActivityTime { get; set; }

        [Required(ErrorMessage = "Please Input Duration Value")]
        public int DurationVal { get; set; }

        [Required(ErrorMessage = "Please Input Duration Unit")]
        public string DurationUnit { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<JoinedUser> JoinedUsers { get; set; }
        public Activity(){
            JoinedUsers = new List<JoinedUser>();
        }
    }
}