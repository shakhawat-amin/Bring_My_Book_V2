using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class DepartmentGroup
    {
        public int DepartmentGroupId { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<User> DepartmentGroupUsers { get; set; }
        public ICollection<Post> Posts { get; set; }


    }
}