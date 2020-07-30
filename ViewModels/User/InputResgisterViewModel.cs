using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.ViewModels.User
{
    public class InputResgisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassowrd { get; set; }
        [Required]
        public string UserPin { get; set; }
    }
}
