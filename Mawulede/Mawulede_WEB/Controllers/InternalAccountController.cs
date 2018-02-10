using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Mawulede_WEB.Models;
using Npgsql;
using System.Configuration;
using Mawulede_Models.Model;
using System.Collections.Generic;
using Mawulede_Helpers;

namespace coreERPFMFlyerWeb.Controllers
{
    public class InternalAccountController : Controller
    {

        private static string _Ycon = ConfigurationManager.AppSettings["WRITE_CON_STR"];
       

        // GET: Customer
        public ActionResult LogIn(string returnUrl)
        {
            if (Request.UrlReferrer != null)
                returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
            }
            return View();
        }

        [HttpPost]
        // POST: Customer
        //public ActionResult LogIn(Models.LogInViewModel model, string returnUrl)
        public ActionResult LogIn(Mawulede_WEB.Models.LoginModel model, string returnUrl)
        {
            if (model.username == null || model.password == "")
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }


             DBHelper.Instance.Login(model, returnUrl);

            //using (var con = new NpgsqlConnection(_Ycon))
            //{
            //    var results = new List<User>();

            //    var cmd = new NpgsqlCommand("\"GetAllStatus\"", con);
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //    con.Open(); var reader = cmd.ExecuteReader();

            //    con.Close(); con.Dispose();
            //    return results;

            //}



            //var user = db.employeeUsers.FirstOrDefault(p => p.userName == model.username && p.accessLevelId>0);
            //var user = db.employeeUsers.FirstOrDefault(p => p.userName == model.username && p.password==model.password);
            //if (user == null)
            //{
            //    ViewBag.Error = "Invalid Credentials";
            //    return View();
            //}
            return View();
        }

        //// GET: Customer
        //public ActionResult LogOut()
        //{
        //    try
        //    {
        //        keepfitEntities db = new keepfitEntities();
        //        var user = db.employeeUsers.First(p => p.userName == User.Identity.Name);
        //        var tokens = user.employeeUserLoginTokens
        //            .Where(p => p.expiryDate > DateTime.Now);
        //        foreach (var token in tokens)
        //        {
        //            token.expiryDate = DateTime.Now.AddMinutes(-1);
        //        }
        //        db.SaveChanges();
        //    }
        //    catch (Exception) { }
        //    FormsAuthentication.SignOut();
        //    Session.Clear();
        //    return RedirectToAction("LogIn", "InternalAccount");
        //}
         
        //public ActionResult ChangePassword()
        //{
        //    if (TempData["Message"] != null)
        //    {
        //        ViewBag.Message = TempData["Message"].ToString();
        //    }
        //    return View();
        //}

        //[HttpPost] 
        //// POST: Customer
        //public ActionResult ChangePassword(Models.PasswordChangeViewModel model)
        //{
        //    if (model.password != model.password2 || User.Identity.Name == null || User.Identity.Name == "")
        //    {
        //        ViewBag.Error = "Passwords do not match";
        //        return View();
        //    }
        //    keepfitEntities db = new keepfitEntities();
        //    var user = db.employeeUsers.FirstOrDefault(p => p.userName == User.Identity.Name);
        //    if (user == null)
        //    {
        //        ViewBag.Error = "!Invalid entries! Please correct and continue";
        //        return View();
        //    }

        //    //Encode Password and check against old password
        //    var oldPassword = PasswordManager.EncodePassword(model.oldpassword, user.userName);
        //    if (user.password != oldPassword)
        //    {
        //        ViewBag.Error = "Invalid entries! Please correct and continue";
        //        return View();
        //    }

        //    //Encode new Password and check in History
        //    var newPassword = PasswordManager.EncodePassword(model.password, user.userName);
        //    if (newPassword == user.password || PasswordInHistory(user, newPassword) == true)
        //    {
        //        ViewBag.Error = "Invalid entries! Password used recently and cannot be repeated.";
        //        return View();
        //    }

        //    user.mustChangePassword = false;
        //    user.passwordAttemptCount = 0;
        //    user.locked = false;
        //    user.lastPasswordChanged = DateTime.Now;
             
        //    //Set new password for user
        //    user.password = newPassword;
              
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbEntityValidationException dex)
        //    {
        //        throw new ApplicationException(dex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage + "| "
        //            + dex.EntityValidationErrors.First().ValidationErrors.First().PropertyName);
        //    } 
        //    FormsAuthentication.SetAuthCookie(user.userName, true);
             
        //    return RedirectToAction("Index", "Home");
        //}

        //private bool PasswordInHistory(employeeUser user, string newHashedPassword)
        //{
        //    bool found = false;

        //    //var hist = user..FirstOrDefault(p => p.password == newHashedPassword);
        //    //if (hist != null)
        //    //{
        //    //    found = true;
        //    //}

        //    return found;
        //}

    }
}