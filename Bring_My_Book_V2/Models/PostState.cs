using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class PostState
    {
        public int PostStateId{get; set;}
        public int postId { get; set; }
        public User PostMan { get; set; }
        public User AcceptedUser { get; set; }
    }
}