using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task_03_advanced_user_management_system.Models;

namespace task_03_advanced_user_management_system.Controllers
{
    public class HomeController : Controller
    {
        private AdvanceUMSEntities db = new AdvanceUMSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Login page work start here
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel logindata)
        {
            if(ModelState.IsValid)
            {
                var loginStatus=db.User_Role.Where(u => u.Email == logindata.Email && u.Password == logindata.Password).FirstOrDefault();
                if (loginStatus!=null)
                {
                    var userData = db.Accounts.Where(a => a.Acc_ID == loginStatus.Account_ID).FirstOrDefault();
                    var userType = db.Account_type.Where(at => at.account_type_id == userData.Account_Type_ID).FirstOrDefault();


                    #region Session Code
                    Session["user_id"] = userData.Acc_ID;
                    Session["first_name"] = userData.First_Name;
                    Session["last_name"] = userData.Last_Name;
                    Session["email"] = userData.Email;
                    Session["gender"] = userData.Gender;
                    Session["account_type_id"] = userData.Account_Type_ID;
                    Session["account_type"] = userType.account_type_name;
                    Session["address1"] = userData.Address1;
                    Session["address2"] = userData.Address2;
                    Session["joining_date"] = loginStatus.Joining_Date;
                    Session["password"] = loginStatus.Password;
                    #endregion
                    if (userData.Account_Type_ID==1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                    
                }
                else
                {
                    ViewBag.loginStatus = "Email or Password doesn't Exist.....";
                    return View();

                }
            }
            else
            {
                ViewBag.loginStatus = "Email or Password doesn't Exist.....";
                return View();

            }
        }
        #endregion

        #region SignUp page Code here
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel newUserData)
        {
            if (ModelState.IsValid)
            {
                Account newAccount = new Account();
                newAccount.Account_Type_ID = 3;
                newAccount.First_Name = newUserData.FirstName;
                newAccount.Last_Name = newUserData.LastName;
                newAccount.Email = newUserData.Email;
                newAccount.Gender = newUserData.Gender;
                db.Accounts.Add(newAccount);
                _ = db.SaveChanges();
                var maximumId = db.Accounts.OrderByDescending(x => x.Acc_ID).FirstOrDefault().Acc_ID;
                User_Role newRole = new User_Role();
                newRole.Account_ID = maximumId;
                newRole.Email = newUserData.Email;
                newRole.Password = newUserData.Password;
                newRole.Joining_Date = DateTime.Now;
                db.User_Role.Add(newRole);
                _ = db.SaveChanges();
                var loginStatus = db.User_Role.Where(u => u.Email == newUserData.Email && u.Password == newUserData.Password).FirstOrDefault();
                var userType = db.Account_type.Where(at => at.account_type_id == newAccount.Account_Type_ID).FirstOrDefault();

                #region Session Code2
                Session["user_id"] = maximumId;
                Session["first_name"] = newUserData.FirstName;
                Session["last_name"] = newUserData.LastName;
                Session["email"] = newUserData.Email;
                Session["gender"] = newUserData.Gender;
                Session["account_type_id"] = newAccount.Account_Type_ID;
                Session["account_type"] = userType.account_type_name;
                Session["address1"] = newAccount.Address1;
                Session["address2"] = newAccount.Address2;
                Session["joining_date"] = loginStatus.Joining_Date;
                Session["password"] = loginStatus.Password;
                #endregion
                //ViewBag.loginStatus = "account not created successfully.....";
                return RedirectToAction("Index","User");
            }
            else
            {
                ViewBag.loginStatus = "account not created successfully.....";
                return View();
            }
        }
        #endregion 
    }
}