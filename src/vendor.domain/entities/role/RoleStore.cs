using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using vendor.domain.data.concretes;

namespace vendor.domain.entities
{
    public class RoleStore : RoleStore<Role, VendorDbContext, long>//, UserRole, RoleClaim>
    {
        public RoleStore(VendorDbContext context) : base(context) { }
        //protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
