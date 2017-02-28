using System;

namespace activityCenter.Models{

    public class JoinedUser : BaseEntity{
        public int JoinedUserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Updatedat { get; set; }
        
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}