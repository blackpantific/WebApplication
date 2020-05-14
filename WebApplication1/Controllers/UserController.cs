using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                userModel.Date = DateTime.Now;
                dbModel.User.Add(userModel);
                dbModel.SaveChanges();
            }

            ModelState.Clear();
            /*return View("AddOrEdit", new User());*/
            return RedirectPermanent("~/Home/Contact");
        }
    }
}