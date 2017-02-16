using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using vendor.domain.data.abstracts;
using vendor.domain.entities.manytomany;

namespace vendor.domain.entities
{
    public class User : IdentityUser<long> /*, UserClaim, UserRole, UserLogin>*/, IEntity
    {
        public byte[] Image { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Update { get; set; }
        public bool IsBlocked { get; set; }

        public Language Language { get; set; }
        public Product Product { get; set; }
        public Language UserLanguage { get; set; }
        // public ICollection<UserLanguage> UserLanguages { get; set; } = new HashSet<UserLanguage>(); 
        public ICollection<UserProduct> UserProducts { get; set; } = new HashSet<UserProduct>();
        public ICollection<ProductLanguage> ProductLanguages { get; set; } = new HashSet<ProductLanguage>();
    }
}

