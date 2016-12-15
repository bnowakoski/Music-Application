using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Music.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime DateJoined { get; set; }
    }
}