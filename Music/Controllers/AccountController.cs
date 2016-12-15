using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Music.Models;
using Music.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace Music.Controllers
{
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNet.Identity.UserManager<AppUser> userManager;

        public AccountController()
            : this(Startup.UserManagerFactory.Invoke())
        {

        }

        public AccountController(Microsoft.AspNet.Identity.UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Home");
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }





        // GET: Account
        public ActionResult Index()
        {
            return View("Register");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(RegisterViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, DateJoined = System.DateTime.Now, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    await SignIn(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Register");
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
    }
}