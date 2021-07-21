using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task_03_advanced_user_management_system.Models;

namespace task_03_advanced_user_management_system.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private AdvanceUMSEntities db = new AdvanceUMSEntities();
        public ActionResult Index()
        {
            if ((bool)(Session["user_id"] != null))
            {
                if ((int)Session["account_type_id"] == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login","Home");
                }
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }

        public ActionResult AdminProfile()
        {
            if ((bool)(Session["user_id"] != null))
            {
                if ((int)Session["account_type_id"] == 1)
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
        public ActionResult Users()
        {
            if ((bool)(Session["user_id"] != null))
            {
                if ((int)Session["account_type_id"] == 1)
                {
                    
                    return View(db.Accounts.ToList());
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

        [HttpGet]
        public ActionResult ChangeType(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Users", "Admin");
            }
            var user = db.Accounts.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangeType(int? id,string name,int type)
        {
            if (id == null)
            {
                return RedirectToAction("Users", "Admin");
            }
            var user = db.Accounts.Find(id);
            user.Account_Type_ID = type;
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users","Admin");
        }
        public ActionResult ViewUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account user = db.Accounts.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Users", "Admin");
            }
            var role = db.User_Role.Find(id);
            db.User_Role.Remove(role);
            db.SaveChanges();
            var user = db.Accounts.Find(id);
            db.Accounts.Remove(user);
            db.SaveChanges();
           
            return RedirectToAction("Users", "Admin");
        }

        public ActionResult Logout()
        {
            if((bool)(Session["user_id"] == null))
            {
                Session.RemoveAll();
                Session.Clear();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}