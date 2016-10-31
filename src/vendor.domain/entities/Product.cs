using System;
using System.Collections.Generic;
using vendor.domain.data.abstracts;
using vendor.domain.entities.dictionaries;

namespace vendor.domain.entities
{
    public class Product : IEntity
    {
        public Product()
        {
            Languages = new HashSet<ProductDict>();
        }

        public long Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Update { get; set; }
        public long UserUpdateId { get; set; }

        public virtual ICollection<ProductDict> Languages { get; set; }
        public virtual User UserUpdate { get; set; }
    }
}
