using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.ViewModels.Auth
{
    public class InputLoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
