using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7Assignment.Models
{
    //Inherits from the IdentityDbContext class template
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        //Constructor for the class
        public AppIdentityDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
