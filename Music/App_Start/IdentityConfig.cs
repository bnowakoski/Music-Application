using Music.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;


namespace Music.Model
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
           app.CreatePerOwinContext(() => new MusicContext());
          

          //  app.UseCookieAuthentication(new CookieAuthenticationOptions
           // {
               // AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
               // LoginPath = new PathString("/Home/Login"),
           // });
        }
    }
}