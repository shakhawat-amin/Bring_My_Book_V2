﻿using System;
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

    [Authorize(Roles = "Student")]
    public class BatchController : Controller
    {
        // GET: Batch
        private ApplicationDbContext context = new ApplicationDbContext();
        User userInfo;
        private int batchYear;
        public BatchController ()
        {
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userInfo = context.UserInfo.FirstOrDefault(user => user.UserIdentityId == userId);
            

        }
        public ActionResult Index()
        {
            var posts = new Collection<Post>();
            batchYear = context.Batches.FirstOrDefault(batch => batch.BatchId.Equals(userInfo.BatchId)).BatchYear;

            foreach (var item in context.Posts.Include(b => b.PostUser).ToList())
            {
                //if(item.PostUser.userRole.Equals("Student") && item.PostBatch.Equals(batchYear))
                    posts.Add(item);

            }
                
            ViewBag.TotalPost = posts.Count();
            ViewBag.userId = userInfo.UserId;
            ViewBag.batch = batchYear;
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


                if (userInfo.userRole.Equals("Student"))
                {
                    Post.PostBatch = context.Batches.FirstOrDefault(user => user.BatchId == userInfo.BatchId).BatchYear;
                }
                Post.check = false;

                context.Posts.Add(Post);

                context.SaveChanges();
                return RedirectToAction("Index", "Batch");

            }


            //something went wrong. 
            return View(Post);

        }


    }
}