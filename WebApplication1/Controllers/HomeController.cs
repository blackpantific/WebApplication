using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
     
            return View();
        }

        public ActionResult Contact()
        {
             using (DbModels dbModel = new DbModels())
             {
                var listOfUsers = dbModel.User.ToList();
                var listOfUsersWithCount = listOfUsers.Select(item =>
               {
                   return new UserCount
                   {
                       Id = item.Id,
                       Name = item.Name,
                       Date = item.Date,
                       Description = item.Description,
                       Email = item.Email,
                       Count = listOfUsers.Count(email => email.Email == item.Email)
                   };
               });

                var usersWithCount = new List<UserCount>();

                foreach (var item in listOfUsersWithCount)
                {
                    usersWithCount.Add(item);
                }


                 return View(usersWithCount);
             }
           
        }

        

    }
}