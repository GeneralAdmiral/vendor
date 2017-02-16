using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using vendor.domain.data.concretes;

namespace vendor.domain.entities
{
    public class UserStore : UserStore<User, Role, VendorDbContext, long>//UserStore<IdentityUser<long>, IdentityRole<long>, VendorDbContext, long>
    {
        public UserStore(VendorDbContext context) : base(context) { }
    }
}
