using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class Batch
    {
        public int   BatchId{get; set;}
        public int BatchYear { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}