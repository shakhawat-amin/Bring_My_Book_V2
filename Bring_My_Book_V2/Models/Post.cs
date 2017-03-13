using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostDescription { get; set; }

        public DateTime PostDateTime {get; set;}
        public User PostUser { get; set; }
        public string PostDept { get; set; }
        public string PostBatch { get; set; } 
        public ICollection<User> UserInterested { get; set; }
        public List<User> UserInterestedList { get; set; }
 

    }
}