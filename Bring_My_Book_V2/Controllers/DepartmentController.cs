﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department

        private ApplicationDbContext context = new ApplicationDbContext();
        User userInfo;
        public DepartmentController()
        {

            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            
            //var userID = User.Identity.GetUserId();
            //var check = User.Identity.IsAuthenticated; 
            //var userID = SignInManager.AuthenticationManager.AuthenticationResponseGrant.Identity.GetUserId();
            //var claimsIdentity = User.Identity as ClaimsIdentity;
            //string userIdValue = null;
            //if (claimsIdentity != null)
            //{
            //    // the principal identity is a claims identity.
            //    // now we need to find the NameIdentifier claim
            //    var userIdClaim = claimsIdentity.Claims
            //        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            //    if (userIdClaim != null)
            //    {
            //         userIdValue = userIdClaim.Value;
            //    }
            //}

            userInfo = context.UserInfo.FirstOrDefault(user => user.UserIdentityId == userId);
        }

        
        public ActionResult Index()
        {
            var posts = new Collection<Post>();
            
            //var dummy = new Collection<Post>() {
            //new Post{PostId = 1, PostBatch = 2004, PostDept = "Economics", PostDescription = "adlkfaldkfadsf adfsads fdsf",
            //        PostUser = userInfo, PostDateTime = new DateTime(2016, 1, 21)},
            //new Post{PostId = 2, PostBatch = 2012, PostDept = "Anthropology", PostDescription = "Paper donshon e donshito",
            //        PostUser = userInfo, PostDateTime = new DateTime(2016, 9, 23)},
            //new Post{PostId = 3, PostBatch = 2002, PostDept = "CSE", PostDescription = "Kaldi or khaldi thesis pass korte hobe",
            //        PostUser = userInfo, PostDateTime = new DateTime(2011, 1, 3)},
            //new Post{PostId = 4, PostBatch = 1999, PostDept = "CEP", PostDescription = "Deep speech",
            //        PostUser = userInfo, PostDateTime = new DateTime(2012, 9, 17)},
            
            //new Post{PostId = 5, PostBatch = 1998, PostDept = "BBA", PostDescription = "Masum sir 100 taka",
            //        PostUser = userInfo, PostDateTime = new DateTime(2011, 9, 17)}
            
            //};

            //ViewBag.TotalPost = dummy.Count();
            //dummy.OrderByDescending(m => m.PostDateTime.Year).
            //ThenByDescending(m => m.PostDateTime.Month).ThenByDescending(m => m.PostDateTime.Day);
            //dummy.OrderBy(d => d.PostDateTime);
            //return View(dummy); 

            foreach (var item in context.Posts.Include( b => b.PostUser).ToList())
            {
                //if(item.check.Equals(false) && !item.PostUser.UserId.Equals(userInfo.UserId))
                    posts.Add(item);
            }
               
            ViewBag.TotalPost = posts.Count();
            ViewBag.userId = userInfo.UserId;
            ViewBag.dept = context.Departments.FirstOrDefault(user => user.DepartmentId == userInfo.DepartmentId).DepartmentName;
            return View(posts);
        }

        
        public ActionResult Index1( Post post)
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
                

                if (userInfo.userRole.Equals("Student"))
                {
                    Post.PostBatch = context.Batches.FirstOrDefault(user => user.BatchId == userInfo.BatchId).BatchYear;
                }
                Post.check = false;

                context.Posts.Add(Post);
                
                context.SaveChanges();
                return RedirectToAction("Index", "Department");

            }
            
            
            //something went wrong. 
            return View(Post);

        }



    }
}