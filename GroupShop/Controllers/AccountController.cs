using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using GroupShop.Models;
using System.Data.Entity.Validation;




namespace GroupShop.Models
.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

       

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                MemberDbContext memberDb = new MemberDbContext();
                

                var user = memberDb.Members.SingleOrDefault(m => m.PersonId == model.UserName);
                if (user != null)
                {
                    Session.Add("LoginMemberId", user.MemberId);
                    Session.Add("LoginPersonId", user.PersonId);
                    Session.Add("LoginName", user.Name);
                    //await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    
                    ModelState.AddModelError("", "Invalid username or password.");

                    
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

     



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Helpers










        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }












        #endregion
    }
}