using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bring_My_Book_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Bring_My_Book_V2.Controllers;

namespace Bring_My_Book_V2.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        private ApplicationDbContext context = new ApplicationDbContext();
        User userInfo;
        public BatchController ()
        {
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userInfo = context.UserInfo.FirstOrDefault(user => user.UserIdentityId == userId);
        }
        public ActionResult Index()
        {
            var posts = new Collection<Post>();
            //foreach (var item in context.Posts)
            //    posts.Add(item);
            var dummy = new Collection<Post>() {
            new Post{PostId = 1, PostBatch = 2004, PostDept = "Economics", PostDescription = "adlkfaldkfadsf adfsads fdsf",
                    PostUser = userInfo, PostDateTime = new DateTime(2016, 1, 21)},
            new Post{PostId = 2, PostBatch = 2012, PostDept = "Anthropology", PostDescription = "Paper donshon e donshito",
                    PostUser = userInfo, PostDateTime = new DateTime(2016, 9, 23)},
            new Post{PostId = 3, PostBatch = 2002, PostDept = "CSE", PostDescription = "Kaldi or khaldi thesis pass korte hobe",
                    PostUser = userInfo, PostDateTime = new DateTime(2011, 1, 3)},
            new Post{PostId = 4, PostBatch = 1999, PostDept = "CEP", PostDescription = "Deep speech",
                    PostUser = userInfo, PostDateTime = new DateTime(2012, 9, 17)},
            
            new Post{PostId = 5, PostBatch = 1998, PostDept = "BBA", PostDescription = "Masum sir 100 taka",
                    PostUser = userInfo, PostDateTime = new DateTime(2011, 9, 17)}
            
            };

            ViewBag.TotalPost = dummy.Count();
            dummy.OrderByDescending(m => m.PostDateTime.Year).
            ThenByDescending(m => m.PostDateTime.Month).ThenByDescending(m => m.PostDateTime.Day);
            //dummy.OrderBy(d => d.PostDateTime);
            return View(dummy);
        }
    }
}