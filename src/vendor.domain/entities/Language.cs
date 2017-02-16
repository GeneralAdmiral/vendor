using System;
using System.Collections.Generic;
using vendor.domain.data.abstracts;
using vendor.domain.entities.manytomany;

namespace vendor.domain.entities
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string Alias { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public DateTime Update { get; set; }
        public long UserUpDateId { get; set; }
        public long UserUpdateId { get; set; }

        public User UserLanguage { get; set; }
        public ICollection<ProductLanguage> ProductLanguages { get; set; } = new HashSet<ProductLanguage>();
         public User UserUpdate { get; set; }
    }
}
