using System;
using System.Collections.Generic;
using vendor.domain.data.abstracts;
using vendor.domain.entities.manytomany;

namespace vendor.domain.entities
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime Update { get; set; }
        public long UserUpdateId { get; set; }
        
        public ICollection<ProductLanguage> ProductLanguages { get; set; } = new HashSet<ProductLanguage>();
        public ICollection<UserProduct> UserProducts { get; set; } = new HashSet<UserProduct>();
        public User UserUpdate { get; set; }
    }
}
