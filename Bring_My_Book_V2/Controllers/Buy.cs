using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Bring_My_Book_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Bring_My_Book_V2.Controllers;

namespace Bring_My_Book_V2.Controllers
{

    [Authorize]
    public class BuyController : Controller
    {
        // GET: Batch
        private ApplicationDbContext context = new ApplicationDbContext();
        User userInfo;
       
        public BuyController ()
        {
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userInfo = context.UserInfo.FirstOrDefault(user => user.UserIdentityId == userId);
            

        }
        public ActionResult Index()
        {
            var posts = new Collection<Post>();
            //batchYear = context.Batches.FirstOrDefault(batch => batch.BatchId.Equals(userInfo.BatchId)).BatchYear;

            foreach (var item in context.Posts.Include(b => b.PostUser).Include(b => b.Buyers).ToList())
            {
                System.Console.WriteLine(item.Buyers);
                System.Console.WriteLine(11111);
                //if(item.PostUser.userRole.Equals("Student") && item.PostBatch.Equals(batchYear))
                    posts.Add(item);

            }
                
            ViewBag.TotalPost = posts.Count();
            ViewBag.userId = userInfo.UserId;
            var p = posts.OrderBy(b => b.PostDateTime);
            
            return View(posts);
        }


        public ActionResult Index1(Post post1)
        {
            var post = context.Posts.Include(p => p.Buyers).FirstOrDefault(p => p.PostId.Equals(post1.PostId));
            post.BuyerId = userInfo.UserId;
            post.Buyers.Add(userInfo);
            post.check = true;
            context.SaveChanges();
            //return View(post);
            return RedirectToAction("Index");
        }

        public ActionResult Post()
        {
            var Post = new Post();
            return View(Post);
        }


        [HttpPost]
        public ActionResult Post(Post Post)
        {

            if (ModelState.IsValid)
            {
                Post.PostUser = userInfo;
                Post.PostDept = context.Departments.FirstOrDefault(user => user.DepartmentId == userInfo.DepartmentId).DepartmentName;

                Post.PostDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Post.PostUpdateTime = Post.PostDateTime;

                if (userInfo.userRole.Equals("Student"))
                {
                    Post.PostBatch = context.Batches.FirstOrDefault(user => user.BatchId == userInfo.BatchId).BatchYear;
                }
               
                
                Post.check = false;

                context.Posts.Add(Post);

                context.SaveChanges();
                return RedirectToAction("Index", "Buy");

            }


            //something went wrong. 
            return View(Post);

        }


    }
}