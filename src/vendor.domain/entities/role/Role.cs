using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace vendor.domain.entities
{
    public class Role : IdentityRole<long>//, UserRole, RoleClaim>
    {
        public Role()
        {
        }

        public Role(string roleName)
        {
            this.Name = roleName;
        }
        
        public DateTime Update { get; set; }
    }
}
