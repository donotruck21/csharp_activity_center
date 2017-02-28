using System;
using System.Collections.Generic;

namespace activityCenter.Models{

    public class Activity : BaseEntity{
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime ActivityTime { get; set; }
        public int DurationVal { get; set; }
        public string DurationUnit { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<JoinedUser> JoinedUsers { get; set; }
        public Activity(){
            JoinedUsers = new List<JoinedUser>();
        }
    }
}