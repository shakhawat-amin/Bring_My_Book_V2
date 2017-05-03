using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bring_My_Book_V2.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string PostDescription { get; set; }

        public DateTime PostDateTime {get; set;}

        // type buy sell
        //update time
        //

        public double Price { get; set; }
        public User PostUser { get; set; }
        public string PostDept { get; set; }
        public int PostBatch { get; set; }
        public int BuyerId { get; set; }
        public bool check { get; set; }
        public ICollection<int> UserInterestedId { get; set; }
        public List<int> UserInterestedListId { get; set; }
 

    }
}