using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_03_advanced_user_management_system.Models;

namespace task_03_advanced_user_management_system.Controllers
{
    public class UserController : Controller
    {

        private AdvanceUMSEntities db = new AdvanceUMSEntities();
        // GET: User
        public ActionResult Index()
        {
            if ((bool)(Session["user_id"] != null))
            {
                if ((int)Session["account_type_id"] !=1 )
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult UserProfile()
        {
            ProfileModel pm = new ProfileModel();
            pm.First_Name =(string) Session["first_name"];
            pm.Last_Name =(string) Session["last_name"];
            pm.Email = (string)Session["email"];
            pm.Gender = (string)Session["gender"];
            pm.Address1 = (string)Session["address1"];
            pm.Address2 = (string)Session["address2"];
            return View(pm);
        }

        public ActionResult UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProfile(ProfileModel pm)
        {
            if (ModelState.IsValid)
            {
                var db2 = new AdvanceUMSEntities();
                int id = System.Convert.ToInt32(Session["user_id"]);
                var entity = db.Accounts.Where(m => m.Acc_ID ==id).SingleOrDefault();
                entity.First_Name = pm.First_Name;
                entity.Last_Name = pm.Last_Name;
                entity.Email = pm.Email;
                entity.Gender = pm.Gender;
                entity.Address1 = pm.Address1;
                entity.Address2 = pm.Address2;
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session["first_name"] = pm.First_Name;
                Session["last_name"] = pm.Last_Name;
                Session["email"] = pm.Email;
                Session["gender"] = pm.Gender;
                Session["address1"] = pm.Address1;
                Session["address2"] = pm.Address2;

                return RedirectToAction("UserProfile","User");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            if ((bool)(Session["user_id"] == null))
            {
                Session.RemoveAll();
                Session.Clear();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}