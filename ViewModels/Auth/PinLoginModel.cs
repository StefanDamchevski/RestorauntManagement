using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.ViewModels.Auth
{
    public class PinLoginModel
    {
        [Required]
        public string UserPin { get; set; }
    }
}