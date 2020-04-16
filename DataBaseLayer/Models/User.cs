using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Models
{
   public class User:IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
