using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using vendor.domain.data.abstracts;

namespace vendor.domain.entities
{
    public class User : IdentityUser<long> /*, UserClaim, UserRole, UserLogin>*/, IEntity
    {
        public User()
        {
            Languages = new HashSet<LanguageDict>();
        }
        public byte[] Image { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<LanguageDict> Languages { get; set; } = new HashSet<LanguageDict>();
    }
}

