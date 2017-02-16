using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendor.domain.entities.manytomany
{
    public class UserLanguage
    {
        public long ParentId { get; set; }
        public long LanguageId { get; set; }
        // public DateTime Update { get; set; }
        public long UserUpdateId { get; set; }

        public User Parent { get; set; }
        public Language Language { get; set; }
    }
}
