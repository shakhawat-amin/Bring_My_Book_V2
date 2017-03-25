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

        public ActionResult Post()
        {
            var Post = new Post();
            return View(Post);
        }

        [HttpPost]
        public ActionResult Post(Post Post)         //Have to work on it
        {
            return View();
        }



    }
}