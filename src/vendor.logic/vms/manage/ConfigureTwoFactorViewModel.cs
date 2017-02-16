using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace vendor.logic.vms.manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
