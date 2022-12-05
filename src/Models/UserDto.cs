using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserDto
    {
        private string
           _email = String.Empty,
           _password = String.Empty,
           _confirmPassword = String.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get => _email; set => _email = value; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Password { get => _password; set => _password = value; }

        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value; }
    }
}
