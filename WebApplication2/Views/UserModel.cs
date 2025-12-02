using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Views
{
    public class UserModel
    {

        [Required(ErrorMessage = "Должно быть обязательно указано.")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Должно быть обязательно указано.")]
        [EmailAddress(ErrorMessage = "Должна соответствовать формату email.")]
        public string Email { get; set; }


        [MinLength(8, ErrorMessage = "Должен быть не короче 8 символов.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Только буквы и цифры.")]//!!
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Должен совпадать с паролем.")]
        public string ReqvestPassword {  get; set; }


        [Range(18, 99, ErrorMessage = "Возраст должен быть между 18 и 100.")]
        public int Age {  get; set; }


        [Required(ErrorMessage = "Должно быть обязательно указано.")]
        [Phone(ErrorMessage = "Должен соответствовать формату телефона (например, \"+7(999)123-45-67\").")]
        public string PhoneNumber {  get; set; }


        [Required(ErrorMessage = "Должно быть обязательно указано.")]

        public string Add {  get; set; }
    }
}
