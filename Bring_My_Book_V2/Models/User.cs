using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Bring_My_Book_V2.Models
{
    public class User
    {
        public int  UserId  {get; set;}          //User.Identity.GetUserId();
        public string UserIdentityId { get; set; }
        public  Department Department { get; set; }
        public  Batch Batch { get; set; }
        public string RegistrationNumber { get; set; }
        public string designation { get; set; }
        
        public string phoneNumber { get; set; }
        public string userRole { get; set; }
       // public IdentityRole userRoleIdentity { get; set; }
    }
}