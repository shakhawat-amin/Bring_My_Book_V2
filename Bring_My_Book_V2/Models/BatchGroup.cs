using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class BatchGroup
    {
        public int BatchGroupId { get; set; }
        public int BatchId { get; set; }
        public ICollection<User> BatchGroupUsers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}