using System.ComponentModel.DataAnnotations;

namespace Kursach.Models.ViewModels
{
    public class RegisterModel
    {
        [StringLength(60, MinimumLength = 4)]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Required(ErrorMessage = "Не указан Name")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
