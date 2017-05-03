using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Bring_My_Book_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Bring_My_Book_V2.Controllers;

namespace Bring_My_Book_V2.Controllers
{

     [Authorize(Roles = "Teacher")]
    public class ColleagueController : Controller
    {
        // GET: colleague
       

        private ApplicationDbContext context = new ApplicationDbContext();
        User userInfo;
        private int userId1;

        public ColleagueController()
        {
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userInfo = context.UserInfo.FirstOrDefault(user => user.UserIdentityId == userId);
        }
        public ActionResult Index()
        {
           
            var posts = new Collection<Post>();
            foreach (var item in context.Posts.Include(b => b.PostUser).ToList())
            {
                //var u = item.PostUser;
                //var userId1 = u.UserId;
                //var userInfo1 = context.UserInfo.FirstOrDefault(user => user.UserId == userId1);

                //if(userInfo1.userRole.Equals("Teacher") && item.check.Equals(false))  //Colleague logic
                posts.Add(item);
            }

            ViewBag.TotalPost = posts.Count();
            ViewBag.userId = userInfo.UserId;
            ViewBag.dept = context.Departments.FirstOrDefault(user => user.DepartmentId == userInfo.DepartmentId).DepartmentName;
            return View(posts);
        
        }


        public ActionResult Index1(Post post)
        {
            var post1 = context.Posts.FirstOrDefault(p => p.PostId.Equals(post.PostId));
            post1.BuyerId = userInfo.UserId;
            post1.check = true;
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


               
                    //Post.PostBatch = context.Batches.FirstOrDefault(user => user.BatchId == userInfo.BatchId).BatchYear;
                    
                Post.check = false;

                context.Posts.Add(Post);

                context.SaveChanges();
                return RedirectToAction("Index", "Colleague");

            }
            //something went wrong. 
            return View(Post);

        }





    }
}