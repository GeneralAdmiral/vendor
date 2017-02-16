using System;
using System.Collections;
using System.Collections.Generic;

namespace vendor.domain.entities.manytomany
{
    public class ProductLanguage
    {
        public long ParentId { get; set; }
        public long LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public DateTime Update { get; set; }
        public long UserUpdateId { get; set; }

        public Product Parent { get; set; }
        public Language Language { get; set; }
        public User UserUpdate { get; set; }
    }
}
