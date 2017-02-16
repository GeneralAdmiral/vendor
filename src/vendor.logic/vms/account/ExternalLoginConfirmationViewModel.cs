using System.ComponentModel.DataAnnotations;

namespace vendor.logic.vms.account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
