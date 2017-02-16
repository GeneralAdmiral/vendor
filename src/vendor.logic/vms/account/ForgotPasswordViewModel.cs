using System.ComponentModel.DataAnnotations;

namespace vendor.logic.vms.account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
