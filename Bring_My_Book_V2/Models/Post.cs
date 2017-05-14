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
        [Display(Name="Product Name")]
        public string PostName {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string PostDescription { get; set; }

        public DateTime PostDateTime {get; set;}

        public string PostType { get; set; }
        public DateTime PostUpdateTime { get; set; }
        public int TotalSell { get; set; }

        [Required]
        [Display(Name= "Quantity")]
        public int PostQuantity { get; set; }
        public List<User> Buyers { get; set; }
        public List<int> PostBuyers { get; set; }


        // type buy sell
        //update time
        //image load
        //if sell type amount of product
        //public List<int> buyers

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