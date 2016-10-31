using System;
using System.Collections;
using System.Collections.Generic;

namespace vendor.domain.entities.dictionaries
{
    public class ProductDict
    {
        public ProductDict()
        {
            Products = new HashSet<Product>();
            Languages = new HashSet<LanguageDict>();
        }
        public long Id { get; set; }
        public long LanguageId { get; set; }
        public DateTime Update { get; set; }
        public long UserUpdateId { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<LanguageDict> Languages { get; set; }
        public virtual User UserUpdate { get; set; }
    }
}
