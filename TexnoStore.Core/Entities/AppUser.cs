using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; set; }
        public Address Address { get; set; }
    }
}
